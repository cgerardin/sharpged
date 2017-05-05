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

        public static List<string> tempFiles;
        public static Form loginForm;

        private static Socket server = null;
        private static string serverHostname = "";
        private static int serverPort = 0;
        private static bool connectionUp = false;

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

        public static void ServerConnect()
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
            server.Send(Encoding.ASCII.GetBytes(command));
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
            ServerConnect(); // Force le serveur à accepter une dernière connexion pour prendre en compte l'état "arrêté"
            server.Close();
            connectionUp = false;
        }

        public static GedList<GedFile> ServerListFiles()
        {
            // Demande la liste des fichiers
            ServerSend("LIST");

            // Récupère l'objet et le dé-sérialise
            return GedList<GedFile>.Load(new MemoryStream(TransfertManager.Recive(server)));
        }

        public static void ServerSendFile(RemoteGedFile file)
        {
            // Annonce l'envoi d'un fichier
            ServerSend("PUT " + file.originalname);

            // Sérialise et envoie l'objet
            TransfertManager.Send(file.Save(), server);
        }

        public static RemoteGedFile ServerReciveFile(GedFile gedFile)
        {
            // Demande le fichier passé en argument
            ServerSend("GET " + gedFile.hash);

            // Récupère l'objet et le dé-sérialise
            return (RemoteGedFile)GedItem.Load(new MemoryStream(TransfertManager.Recive(server)));
        }

        public static void ServerRenameFile(GedFile gedFile, string title)
        {
            // Renomme le fichier passé en argument
            Program.ServerSend("REN " + gedFile.hash + ";" + title);
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
