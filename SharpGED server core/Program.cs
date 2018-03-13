using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace SharpGED_server_core
{
    class Program
    {

        public static volatile bool _stopServer = false;
        public static ConfigurationManager configuration { get; set; }

        static void Main(string[] args)
        {

            configuration = new ConfigurationManager();
            configuration.Load();

            if (!configuration.exist)
            {
                Console.WriteLine("Fichier de configuration non trouvé !");
                return;
            }

            List<WorkerThread> workers = new List<WorkerThread>();
            long currentWorkerId = 0;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SharpGED server core v0.0.1");
            Console.ForegroundColor = ConsoleColor.White;

            IPAddress listenIpAddress = null;
            if (configuration.values.listenIP.Equals("localhost") || configuration.values.listenIP.Equals("127.0.0.1"))
            {
                listenIpAddress = IPAddress.Loopback;
            }
            else if (!IPAddress.TryParse(configuration.values.listenIP, out listenIpAddress))
            {
                listenIpAddress = Dns.GetHostAddresses(configuration.values.listenIP)[0];
            }

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(listenIpAddress, configuration.values.listenPort));
            listener.Listen(10);

            Console.WriteLine("En écoute à l'adresse " + configuration.values.listenIP + ":" + configuration.values.listenPort + " ...");

            while (!_stopServer)
            {

                workers.Add(new WorkerThread(++currentWorkerId, listener.Accept()));

            }

            Console.WriteLine("Clôture de toutes les connexions...");

            foreach (WorkerThread currentWorker in workers)
            {
                if (currentWorker.Worker != null)
                {
                    currentWorker.Worker.RequestStop();
                    currentWorker.Thread.Join();
                }

            }

            Console.WriteLine("Serveur arrêté.");

        }

    }

}
