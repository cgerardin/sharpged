using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace SharpGED_server
{
    static class FileTransfert
    {

        public static void Send(string uri, Socket handler)
        {
            FileStream inStream = File.OpenRead(uri);

            // Envoie la taille exacte du fichier
            int size = (int)inStream.Length;
            handler.Send(Encoding.ASCII.GetBytes(size.ToString()));

            // Envoie le contenu du fichier
            byte[] fileBytes = new byte[size];
            inStream.Read(fileBytes, 0, size);
            inStream.Close();
            handler.Send(fileBytes);
        }

        public static void Recive(string originalFilename, Socket handler)
        {
            string filename;
            int size;

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
            FileStream outStream = File.OpenWrite(ConfigurationManager.AppSettings.Get("BaseFolder") + "storage\\" + filename);
            outStream.Write(fileBytes, 0, size);
            outStream.Close();
            
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                string sql = "INSERT INTO files (filename, originalFilename, size, title, pages) " +
                "VALUES ('" + filename + "', '" + originalFilename + "', 0, '', 0);";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }

        }

    }
}
