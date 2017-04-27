using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace SharpGED_server
{
    class FileTransfert
    {

        public string baseFolder;

        public FileTransfert()
        {
            baseFolder = ConfigurationManager.AppSettings.Get("BaseFolder");
        }

        public void Send(string filename, Socket handler)
        {
            FileStream inStream = File.OpenRead(baseFolder + "storage\\" + filename);

            // Envoie la taille exacte du fichier
            int size = (int)inStream.Length;
            handler.Send(Encoding.ASCII.GetBytes(size.ToString()));

            // Envoie le contenu du fichier
            byte[] fileBytes = new byte[size];
            inStream.Read(fileBytes, 0, size);
            inStream.Close();
            handler.Send(fileBytes);
        }

        public void Recive(string originalFilename, Socket handler)
        {
            string filename;
            int size;
            string title;
            int pages;

            // Récupère sa taille exacte
            byte[] buffer = new byte[8];
            handler.Receive(buffer);
            size = int.Parse(Encoding.Default.GetString(buffer).Trim());

            // Récupère le fichier et le place dans un tableau
            byte[] fileBytes = new byte[size];
            handler.Receive(fileBytes);

            // Génère un nom de fichier unique avec le SHA-256 du fichier en hexadécimal
            using (SHA256 sha256 = SHA256.Create())
            {
                filename = BitConverter.ToString(sha256.ComputeHash(fileBytes)).Replace("-", "");
            }

            // Ecris le tableau sur le disque
            FileStream outStream = File.OpenWrite(baseFolder + "storage\\" + filename);
            outStream.Write(fileBytes, 0, size);
            outStream.Close();

            // Récupère les métadonnées du PDF
            PdfDocument pdf = PdfReader.Open(baseFolder + "storage\\" + filename);
            title = pdf.Info.Title;
            pages = pdf.PageCount;

            // Insère le tout dans la base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                string sql = "INSERT INTO files (filename, originalFilename, size, title, pages) " +
                "VALUES ('" + filename + "', '" + originalFilename + "', " + size + ", '" + title + "', " + pages + ");";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }

        }

    }
}
