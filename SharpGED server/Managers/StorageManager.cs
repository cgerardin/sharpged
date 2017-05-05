using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpGED_lib;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace SharpGED_server
{
    class StorageManager
    {

        private string baseFolder;
        private Socket client;
        private DatabaseManager database;

        public string BaseFolder { get => baseFolder; set => baseFolder = value; }

        public StorageManager(Socket handler)
        {
            baseFolder = ConfigurationManager.AppSettings.Get("BaseFolder");
            database = new DatabaseManager();
            client = handler;
        }

        public void List()
        {
            // Crée une GedList
            GedList<GedFile> filesList = new GedList<GedFile>();

            using (SQLiteConnection db = database.Connect())
            {
                db.Open();

                // Remplis la liste avec des GedFile
                using (SQLiteDataReader rs = new SQLiteCommand("SELECT * FROM files ORDER BY title ASC;", db).ExecuteReader())
                {
                    GedFile currentGedFile;
                    while (rs.Read())
                    {
                        currentGedFile = new GedFile();
                        currentGedFile.hash = rs["hash"].ToString();
                        currentGedFile.title = rs["title"].ToString();
                        filesList.Add(currentGedFile);
                    }
                }
            }

            // Sérialise l'objet et envoie sa taille puis l'objet lui-même
            TransfertManager.Send(filesList.Save(), client);

        }

        public void Send(string hash)
        {
            // Lit le fichier PDF et place son contenu dans un tableau
            byte[] fileBytes;
            int size;
            using (FileStream inStream = File.OpenRead(baseFolder + "storage\\" + hash))
            {
                size = (int)inStream.Length;
                fileBytes = new byte[size];
                inStream.Read(fileBytes, 0, size);
            }

            // Crée un GedFile
            RemoteGedFile file = new RemoteGedFile();

            using (SQLiteConnection db = database.Connect())
            {
                db.Open();

                string sql = "SELECT * FROM files WHERE hash='" + hash + "';";
                using (SQLiteDataReader rs = new SQLiteCommand(sql, db).ExecuteReader())
                {
                    if (rs.Read())
                    {
                        file.hash = hash;
                        file.originalname = rs["originalname"].ToString();
                        file.size = size;
                        file.title = rs["title"].ToString();
                        file.pages = (int)(long)rs["pages"];
                        file.bytes = fileBytes;
                    }
                }
            }

            // Sérialise et envoie l'objet
            byte[] data = file.Save();
            TransfertManager.Send(data, client);
        }

        public void Recive()
        {
            // Récupère l'objet et le dé-sérialise
            RemoteGedFile file = RemoteGedFile.Load(new MemoryStream(TransfertManager.Recive(client)));

            // Génère un nom de fichier unique comprenant du nom de fichier original, avec son SHA-256 en hexadécimal
            string hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = BitConverter.ToString(sha256.ComputeHash(Encoding.ASCII.GetBytes(file.originalname + DateTime.Now))).Replace("-", "");
            }

            // Ecris le fichier PDF sur le disque
            FileStream outStream = File.OpenWrite(baseFolder + "storage\\" + hash);
            outStream.Write(file.bytes, 0, file.size);
            outStream.Close();

            // Récupère et met à jour les métadonnées du PDF
            PdfDocument pdf = PdfReader.Open(baseFolder + "storage\\" + hash, PdfDocumentOpenMode.Modify);
            pdf.Info.Title = file.title;
            pdf.Save(baseFolder + "storage\\" + hash);
            pdf.Close();

            // Insère le tout dans la base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();

                string sql = "INSERT INTO files (hash, originalname, size, title, pages) " +
                "VALUES ('" + hash + "', '" + file.originalname.Replace("'", "''") + "', " + file.size + ", '" + file.title.Replace("'", "''") + "', " + pdf.PageCount + ");";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }
        }

        public void Delete(string hash)
        {
            // Supprime les métadonnées en base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                new SQLiteCommand("DELETE FROM files WHERE hash = '" + hash + "';", db).ExecuteNonQuery();
            }

            // Supprime le fichier du disque
            File.Delete(baseFolder + "storage\\" + hash);
        }

        public void Rename(string hash, string title)
        {
            // Met à jour les métadonnées en base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                new SQLiteCommand("UPDATE files SET title='" + title + "' WHERE hash = '" + hash + "';", db).ExecuteNonQuery();
            }

            // Met à jour les métadonnées du PDF
            PdfDocument pdf = PdfReader.Open(baseFolder + "storage\\" + hash, PdfDocumentOpenMode.Modify);
            pdf.Info.Title = title;
            pdf.Save(baseFolder + "storage\\" + hash);
            pdf.Close();
        }
    }
}
