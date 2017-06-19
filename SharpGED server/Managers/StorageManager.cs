using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpGED_lib;
using System;
using System.Data.SQLite;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using static SharpGED_lib.GedFile;

namespace SharpGED_server
{
    class StorageManager
    {
        public DatabaseManager database { get; set; }
        public string baseFolder { get; set; }

        private Socket client;

        public StorageManager(Socket handler)
        {
            database = new DatabaseManager();
            baseFolder = Program.configuration.values.baseFolder + "storage\\" + database.name + "\\";
            client = handler;
        }

        public void ListFolders(string filter = "")
        {
            // Crée une GedList des dossiers
            GedList<GedFolder> foldersList = new GedList<GedFolder>();

            using (SQLiteConnection db = database.Connect())
            {
                db.Open();

                // Très important de sélectionner par ordre d'ID, sinon certains parents pourraient être ajoutés après leur enfant
                using (SQLiteDataReader rs = new SQLiteCommand("SELECT * FROM folders ORDER BY idFolder ASC;", db).ExecuteReader())
                {
                    GedFolder currentFolder;
                    while (rs.Read())
                    {
                        currentFolder = new GedFolder();
                        currentFolder.id = (long)rs["idFolder"];
                        currentFolder.title = rs["title"].ToString();
                        currentFolder.files = ListFiles(currentFolder.id, filter);

                        if (rs["idParentFolder"].ToString().Equals(""))
                        {
                            currentFolder.idParent = null;
                            foldersList.Add(currentFolder);
                        }
                        else
                        {
                            currentFolder.idParent = rs["idParentFolder"];
                            foreach (GedFolder existingFolder in foldersList)
                            {
                                GedFolder.AddChild(existingFolder, currentFolder);
                            }
                        }

                    }
                }
            }

            // Sérialise l'objet et envoie sa taille puis l'objet lui-même
            TransfertManager.Send(foldersList.Save(), client);
        }

        public GedList<GedFile> ListFiles(long folderId, string filter = "")
        {
            // Crée une GedList des fichiers contenus dans le dossier spécifié
            GedList<GedFile> filesList = new GedList<GedFile>();

            using (SQLiteConnection db = database.Connect())
            {
                db.Open();

                // Remplis la liste avec des GedFile
                string where = "";
                if (!filter.Equals(""))
                {
                    where = " AND title like '%" + filter + "%'";
                }
                using (SQLiteDataReader rs = new SQLiteCommand("SELECT * FROM files WHERE idFolder= " + folderId + where + " ORDER BY title ASC;", db).ExecuteReader())
                {
                    GedFile currentGedFile;
                    while (rs.Read())
                    {
                        currentGedFile = new GedFile();
                        currentGedFile.type = (GedFileType)rs["idType"];
                        currentGedFile.hash = rs["hash"].ToString();
                        currentGedFile.originalname = rs["originalname"].ToString();
                        currentGedFile.size = (int)(long)rs["size"];
                        currentGedFile.title = rs["title"].ToString();
                        currentGedFile.pages = (int)(long)rs["pages"];
                        currentGedFile.version = (int)(long)rs["version"];
                        filesList.Add(currentGedFile);
                    }
                }
            }

            return filesList;
        }

        public void SendFile(string hash)
        {
            // Lit le fichier PDF et place son contenu dans un tableau
            byte[] fileBytes;
            int size;
            using (FileStream inStream = File.OpenRead(baseFolder + hash))
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
                        file.type = (GedFileType)rs["idType"];
                        file.hash = hash;
                        file.originalname = rs["originalname"].ToString();
                        file.size = size;
                        file.title = rs["title"].ToString();
                        file.pages = (int)(long)rs["pages"];
                        file.version = (int)(long)rs["version"];
                        file.bytes = fileBytes;
                    }
                }
            }

            // Sérialise et envoie l'objet
            byte[] data = file.Save();
            TransfertManager.Send(data, client);
        }

        public void ReciveFile()
        {
            // Récupère l'objet et le dé-sérialise
            RemoteGedFile file = (RemoteGedFile)GedItem.Load(new MemoryStream(TransfertManager.Recive(client)));

            // Génère un nom de fichier unique comprenant du nom de fichier original, avec son SHA-256 en hexadécimal
            string hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = BitConverter.ToString(sha256.ComputeHash(Encoding.Unicode.GetBytes(file.originalname + DateTime.Now))).Replace("-", "");
            }

            // Ecris le fichier PDF sur le disque
            FileStream outStream = File.OpenWrite(baseFolder + hash);
            outStream.Write(file.bytes, 0, file.size);
            outStream.Close();

            if (file.type == GedFileType.PDF)
            {
                // Récupère et met à jour les métadonnées du PDF
                using (PdfDocument pdf = PdfReader.Open(baseFolder + hash, PdfDocumentOpenMode.Modify))
                {
                    pdf.Info.Title = file.title;
                    pdf.Save(baseFolder + hash);
                }
            }

            // Insère le tout dans la base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();

                string sql = "INSERT INTO files (idType, idFolder, hash, originalname, size, title, pages, version) " +
                "VALUES (" + (long)file.type + ", " + file.folderId + ", '" + hash + "', '" + file.originalname.Replace("'", "''") + "', "
                        + file.size + ", '" + file.title.Replace("'", "''") + "', " + file.pages + ", " + file.version + "); ";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }

            // Envoie la confirmation
            client.Send(Encoding.Unicode.GetBytes("OK"));
        }

        public void DeleteFile(string hash)
        {
            // Supprime les métadonnées en base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                new SQLiteCommand("DELETE FROM files WHERE hash = '" + hash + "';", db).ExecuteNonQuery();
            }

            // Supprime le fichier du disque
            File.Delete(baseFolder + hash);

            // Envoie la confirmation
            client.Send(Encoding.Unicode.GetBytes("OK"));
        }

        public void RenameFile(string hash, string title)
        {
            // Met à jour les métadonnées en base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();
                new SQLiteCommand("UPDATE files SET title='" + title + "', version=version+1 WHERE hash = '" + hash + "';", db).ExecuteNonQuery();
            }

            // Met à jour les métadonnées du PDF
            PdfDocument pdf = PdfReader.Open(baseFolder + hash, PdfDocumentOpenMode.Modify);
            pdf.Info.Title = title;
            pdf.Save(baseFolder + hash);
            pdf.Close();
        }

        public void MoveFile(string hash, long id)
        {
            // Change le dossier du fichier en base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();

                new SQLiteCommand("UPDATE files SET idFolder=" + id + " WHERE hash='" + hash + "';", db).ExecuteNonQuery();
            }

            // Envoie la confirmation
            client.Send(Encoding.Unicode.GetBytes("OK"));
        }

        public void CreateFolder()
        {
            // Récupère l'objet et le dé-sérialise
            GedFolder folder = (GedFolder)GedItem.Load(new MemoryStream(TransfertManager.Recive(client)));

            // Crée un nouveau dossiers dans la base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();

                Object idParent = folder.idParent;
                if (idParent == null)
                {
                    idParent = "NULL";
                }

                string sql = "INSERT INTO folders (idParentFolder, title) " +
                "VALUES (" + idParent + ", '" + folder.title.Replace("'", "''") + "');";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }
        }

        public void DeleteFolder(long id)
        {
            // Rattache tous ses enfants et documents à la racine et supprime le dossiers spécifié de la base
            // Nécessite un contrôle de la GUI : La suppression n'est pas récursive
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();

                new SQLiteCommand("UPDATE files SET idFolder=1, version=version+1 WHERE idFolder=" + id + ";", db).ExecuteNonQuery();
                new SQLiteCommand("UPDATE folders SET idParentFolder=1 WHERE idParentFolder=" + id + ";", db).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM folders WHERE idFolder=" + id + ";", db).ExecuteNonQuery();
            }
        }

        public void RenameFolder(long id, string title)
        {
            // Renomme le dossier dans la base
            using (SQLiteConnection db = new DatabaseManager().Connect())
            {
                db.Open();

                new SQLiteCommand("UPDATE folders SET title='" + title.Replace("'", "''") + "' WHERE idFolder=" + id + ";", db).ExecuteNonQuery();
            }
        }

    }
}
