using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpGED_lib;
using System;
using System.Collections.Generic;
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
                // Remplis la liste avec des GedFile
                GedFile currentGedFile;

                db.Open();
                string sql = "SELECT * FROM files;";

                SQLiteDataReader rs = new SQLiteCommand(sql, db).ExecuteReader();
                while (rs.Read())
                {
                    currentGedFile = new GedFile();
                    currentGedFile.hash = rs["hash"].ToString();
                    currentGedFile.title = rs["title"].ToString();
                    filesList.Add(currentGedFile);
                }

            }

            // Sérialise l'objet et envoie sa taille puis l'objet lui-même
            byte[] objectBytes = filesList.Save();
            client.Send(Encoding.ASCII.GetBytes(objectBytes.Length.ToString()));
            client.Send(objectBytes);
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

                SQLiteDataReader rs = new SQLiteCommand(sql, db).ExecuteReader();
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

            // Sérialise l'objet et envoie sa taille puis l'objet lui-même
            byte[] objectBytes = file.Save();
            client.Send(Encoding.ASCII.GetBytes(objectBytes.Length.ToString()));
            client.Send(objectBytes);
        }

        public void Recive()
        {
            // Récupère la taille de l'objet
            byte[] buffer = new byte[8];
            client.Receive(buffer);
            int objectSize = int.Parse(Encoding.Default.GetString(buffer).Trim());

            // Récupère l'objet et le dé-sérialise
            byte[] objectBytes = new byte[objectSize];
            int bytesReceived;
            int bytesTotal = 0;
            int bytesLeft = objectSize;

            while (bytesTotal < objectSize)
            {
                bytesReceived = client.Receive(objectBytes, bytesTotal, bytesLeft, SocketFlags.None);
                if (bytesReceived == 0)
                {
                    objectBytes = null;
                    break;
                }
                bytesTotal += bytesReceived;
                bytesLeft -= bytesReceived;
            }

            RemoteGedFile file = RemoteGedFile.Load(new MemoryStream(objectBytes));

            // Génère un nom de fichier unique avec le SHA-256 du nom de fichier original en hexadécimal
            string hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = BitConverter.ToString(sha256.ComputeHash(Encoding.ASCII.GetBytes(file.originalname))).Replace("-", "");
            }

            // Ecris le fichier PDF sur le disque
            FileStream outStream = File.OpenWrite(baseFolder + "storage\\" + hash);
            outStream.Write(file.bytes, 0, file.size);
            outStream.Close();

            // Récupère et met à jour les métadonnées du PDF
            PdfDocument pdf = PdfReader.Open(baseFolder + "storage\\" + hash, PdfDocumentOpenMode.Modify);
            pdf.Info.Title = file.title;
            pdf.Save(baseFolder + "storage\\" + hash);

            // Insère le tout dans la base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                string sql = "INSERT INTO files (hash, originalname, size, title, pages) " +
                "VALUES ('" + hash + "', '" + file.originalname + "', " + file.size + ", '" + file.title + "', " + pdf.PageCount + ");";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }

            pdf.Close();

        }

    }
}
