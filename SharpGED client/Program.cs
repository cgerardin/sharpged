using SharpGED_lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SharpGED_client
{
    static class Program
    {

        public const int PACKET_SIZE = 1024;

        public static Form loginForm;
        public static string serverHostname = "";
        public static int serverPort = 0;
        public static bool isDatabaseInitialized = false;

        private static Socket server = null;
        private static bool connectionUp = false;
        public static List<string> tempFiles;

        public static string NewTempFile(string extension = "pdf")
        {
            String tempFileUri = Path.GetTempFileName() + "." + extension;
            tempFiles.Add(tempFileUri);

            return tempFileUri;
        }

        public static void CleanTempFiles()
        {
            foreach (string tmpFile in tempFiles)
            {
                try
                {
                    if (File.Exists(tmpFile))
                    {
                        File.Delete(tmpFile);
                    }
                }
                catch (IOException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        public static bool IsConnectionUp()
        {
            return connectionUp;
        }

        public static void ServerConnect(string hostname, int port)
        {
            serverHostname = hostname;
            serverPort = port;
            ServerConnect();
        }

        public static void ServerConnect(bool noDatabase = false)
        {
            IPAddress serverIP = null;

            if (serverHostname.Equals("localhost") || serverHostname.Equals("127.0.0.1"))
            {
                serverIP = IPAddress.Loopback;
            }
            else if (!IPAddress.TryParse(serverHostname, out serverIP))
            {
                serverIP = Dns.GetHostAddresses(serverHostname)[0];
            }

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Blocking = true;
            try
            {
                server.Connect(new IPEndPoint(serverIP, serverPort));
                if (noDatabase) return;

                // Récupère l'état de la base (initialisée ou non)
                byte[] buffer = new byte[sizeof(bool)];
                server.Receive(buffer);

                isDatabaseInitialized = BitConverter.ToBoolean(buffer, 0);
                connectionUp = true;
            }
            catch (SocketException ex)
            {
                connectionUp = false;
                throw ex;
            }
        }

        public static void ServerSend(string command)
        {
            server.Send(Encoding.Unicode.GetBytes(command));
        }

        public static void ServerDisconnect()
        {
            ServerSend("BYE");
            server.Close();
            connectionUp = false;
        }

        public static void ServerHalt()
        {
            ServerSend("STOP");
            ServerConnect(true); // Force le serveur à accepter une dernière connexion pour prendre en compte l'état "arrêté"
            server.Close();
            connectionUp = false;
        }

        public static void ServerInitialize(string databaseName)
        {
            ServerSend("INIT " + databaseName);
            isDatabaseInitialized = true;
        }

        public static GedList<GedFolder> ServerListFolders()
        {
            // Demande la liste des fichiers
            ServerSend("LIST");

            // Récupère l'objet et le dé-sérialise
            return GedList<GedFolder>.Load(new MemoryStream(TransfertManager.Recive(server)));
        }

        public static void ServerSendFile(RemoteGedFile file)
        {
            // Annonce l'envoi d'un fichier
            ServerSend("PUTFILE " + file.originalname);

            // Sérialise et envoie l'objet
            TransfertManager.Send(file.Save(), server);
        }

        public static RemoteGedFile ServerReciveFile(GedFile gedFile)
        {
            // Demande le fichier passé en argument
            ServerSend("GETFILE " + gedFile.hash);

            // Récupère l'objet et le dé-sérialise
            return (RemoteGedFile)GedItem.Load(new MemoryStream(TransfertManager.Recive(server)));
        }

        public static void ServerDeleteFile(GedFile file)
        {
            ServerSend("DELFILE " + file.hash);
        }

        public static void ServerRenameFile(GedFile file, string title)
        {
            // Renomme le fichier passé en argument
            ServerSend("RENFILE " + file.hash + ";" + title);
        }

        public static void ServerCreateFolder(GedFolder folder)
        {
            // Demande la création d'un dossier
            ServerSend("ADDFOLD " + folder.title);

            // Sérialise et envoie l'objet
            TransfertManager.Send(folder.Save(), server);
        }

        public static void ServerDeleteFolder(GedFolder folder)
        {
            // Demande la suppression d'un dossier
            ServerSend("DELFOLD " + folder.id);
        }

        public static void ServerRenameFolder(GedFolder folder, string title)
        {
            // Demande le renommage d'un dossier
            ServerSend("RENFOLD " + folder.id + ";" + title);
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            tempFiles = new List<string>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new LoginForm();
            loginForm.Show();
            Application.Run();
        }

    }
}
