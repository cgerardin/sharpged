using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SharpGED_client
{
    static class Program
    {

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
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(new IPEndPoint(Dns.GetHostEntry(serverHostname).AddressList[1], serverPort));
        }

        public static void ServerSend(string command)
        {
            serverSocket.Send(Encoding.ASCII.GetBytes(command));
        }

        public static void ServerRecive(string filename)
        {

            ServerSend("GET " + filename);

            byte[] bytes = new byte[1024];
            serverSocket.Receive(bytes);
            int size = int.Parse(Encoding.Default.GetString(bytes).Trim());

            byte[] fileBytes = new byte[size];
            serverSocket.Receive(fileBytes);

            FileStream outStream = File.OpenWrite("C:\\TMP\\" + filename);
            outStream.Write(fileBytes, 0, fileBytes.Length);
            outStream.Close();

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
