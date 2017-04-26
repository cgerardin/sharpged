﻿using System;
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

        private static Socket serverSocket = null;
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

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Blocking = true;
            serverSocket.Connect(new IPEndPoint(serverIP, serverPort));
        }

        public static void ServerSend(string command)
        {
            serverSocket.Send(Encoding.ASCII.GetBytes(command));
        }

        public static void ServerDisconnect()
        {
            ServerSend("BYE");
            serverSocket.Close();
        }

        public static void ServerHalt()
        {
            ServerSend("STOP");
            ServerConnect(); // Force le serveur à accepter une dernière connexion pour prendre en compte l'état "arrêté"
            serverSocket.Close();
        }

        public static void ServerSendFile(string filename, string uri)
        {
            // Annonce l'envoi d'un fichier avec son nom d'origine
            ServerSend("PUT " + filename);

            // Place son contenu dans un tableau et envoie sa taille exacte
            FileStream inStream = File.OpenRead(uri);
            int size = (int)inStream.Length;
            ServerSend(size.ToString());

            // Envoie le contenu du tableau
            byte[] fileBytes = new byte[size];
            inStream.Read(fileBytes, 0, size);
            inStream.Close();
            serverSocket.Send(fileBytes);
        }

        public static void ServerReciveFile(string filehash)
        {
            // Demande le fichier passé en argument
            ServerSend("GET " + filehash);

            // Récupère sa taille exacte
            byte[] buffer = new byte[8];
            serverSocket.Receive(buffer);
            int size = int.Parse(Encoding.Default.GetString(buffer).Trim());

            // Récupère le fichier le place dans un tableau
            byte[] fileBytes = new byte[size];
            serverSocket.Receive(fileBytes);

            // Ecris le tableau dans un fichier temporaire sur le disque
            FileStream outStream = File.OpenWrite("C:\\TMP\\" + filehash + ".pdf");
            outStream.Write(fileBytes, 0, size);
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
