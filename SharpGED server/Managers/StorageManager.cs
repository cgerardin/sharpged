using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
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
            using (SQLiteConnection db = database.Connect())
            {
                List<string> filesList = new List<string>();

                db.Open();
                string sql = "SELECT * FROM files;";

                SQLiteDataReader rs = new SQLiteCommand(sql, db).ExecuteReader();
                while (rs.Read())
                {
                    filesList.Add(rs["filename"].ToString());
                }

                client.Send(Encoding.ASCII.GetBytes(filesList.Count.ToString()));

                foreach (string filename in filesList)
                {
                    client.Send(Encoding.ASCII.GetBytes(filename));
                }
            }
        }

        public void Send(string filename)
        {
            FileStream inStream = File.OpenRead(baseFolder + "storage\\" + filename);

            // Envoie la taille exacte du fichier
            int size = (int)inStream.Length;
            client.Send(Encoding.ASCII.GetBytes(size.ToString()));

            // Envoie le contenu du fichier
            byte[] fileBytes = new byte[size];
            inStream.Read(fileBytes, 0, size);
            inStream.Close();
            client.Send(fileBytes);
        }

        public void Recive(string originalname, string title)
        {
            string filename;
            int size;
            int pages;

            client.Send(Encoding.ASCII.GetBytes("READY")); // Cet échange semble nécessaire pour synchro la réception de la taille ?

            // Récupère sa taille exacte
            byte[] buffer = new byte[8];
            client.Receive(buffer);
            size = int.Parse(Encoding.Default.GetString(buffer).Trim());

            // Récupère le fichier et le place dans un tableau
            byte[] fileBytes = new byte[size];
            client.Receive(fileBytes);

            // Génère un nom de fichier unique avec le SHA-256 du fichier en hexadécimal
            using (SHA256 sha256 = SHA256.Create())
            {
                filename = BitConverter.ToString(sha256.ComputeHash(fileBytes)).Replace("-", "");
            }

            // Ecris le tableau sur le disque
            FileStream outStream = File.OpenWrite(baseFolder + "storage\\" + filename);
            outStream.Write(fileBytes, 0, size);
            outStream.Close();

            // Récupère et met à jour les métadonnées du PDF
            PdfDocument pdf = PdfReader.Open(baseFolder + "storage\\" + filename, PdfDocumentOpenMode.Modify);
            pdf.Info.Title = title;
            pages = pdf.PageCount;
            pdf.Save(baseFolder + "storage\\" + filename);
            pdf.Close();

            // Insère le tout dans la base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                string sql = "INSERT INTO files (filename, originalname, size, title, pages) " +
                "VALUES ('" + filename + "', '" + originalname + "', " + size + ", '" + title + "', " + pages + ");";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }

        }

    }
}
