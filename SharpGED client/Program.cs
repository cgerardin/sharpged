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

        private static Socket server = null;
        private static string serverHostname = "";
        private static int serverPort = 0;

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
            server.Connect(new IPEndPoint(serverIP, serverPort));
        }

        public static void ServerSend(string command)
        {
            server.Send(Encoding.ASCII.GetBytes(command));
        }

        public static void ServerDisconnect()
        {
            ServerSend("BYE");
            server.Close();
        }

        public static void ServerHalt()
        {
            ServerSend("STOP");
            ServerConnect(); // Force le serveur à accepter une dernière connexion pour prendre en compte l'état "arrêté"
            server.Close();
        }

        public static List<string> ServerListFiles()
        {
            ServerSend("LIST");

            // Récupère le nombre d'éléments
            byte[] buffer = new byte[8];
            server.Receive(buffer);
            int size = int.Parse(Encoding.Default.GetString(buffer).Trim());

            List<string> filesList = new List<string>();
            for (int i = 0; i < size; i++)
            {
                buffer = new byte[64];
                server.Receive(buffer);

                filesList.Add(Encoding.Default.GetString(buffer));
            }

            return filesList;
        }

        public static void ServerSendFile(GedFile file)
        {
            // Annonce l'envoi d'un fichier
            ServerSend("PUT " + file.originalname);

            // Sérialise l'objet et envoie sa taille puis l'objet lui-même
            byte[] objectBytes = file.Save();
            ServerSend(objectBytes.Length.ToString());
            server.Send(objectBytes);
        }

        public static void ServerReciveFile(string filehash)
        {
            // Demande le fichier passé en argument
            ServerSend("GET " + filehash);

            // Récupère sa taille
            byte[] buffer = new byte[8];
            server.Receive(buffer);
            int objectSize = int.Parse(Encoding.Default.GetString(buffer).Trim());

            // Récupère l'objet et le dé-sérialise
            byte[] objectBytes = new byte[objectSize];
            int bytesReceived;
            int bytesTotal = 0;
            int bytesLeft = objectSize;

            while (bytesTotal < objectSize)
            {
                bytesReceived = server.Receive(objectBytes, bytesTotal, bytesLeft, SocketFlags.None);
                if (bytesReceived == 0)
                {
                    objectBytes = null;
                    break;
                }
                bytesTotal += bytesReceived;
                bytesLeft -= bytesReceived;
            }
            GedFile file = GedFile.Load(new MemoryStream(objectBytes));

            // Ecris le fichier dans un fichier temporaire sur le disque
            FileStream outStream = File.OpenWrite("C:\\TMP\\" + file.hash + ".pdf");
            outStream.Write(file.bytes, 0, file.size);
            outStream.Close();
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new LoginForm().Show();
            Application.Run();
        }

    }
}
