using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace SharpGED_server_core
{
    class Program
    {

        public static volatile bool _stopServer = false;
        public static ConfigurationManager configuration { get; set; }

        static void Main(string[] args)
        {
            string assemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SharpGED server core " + "v" + assemblyVersion.Substring(0, assemblyVersion.Length - 2) + "\n");
            Console.ForegroundColor = ConsoleColor.White;

            configuration = new ConfigurationManager();
            configuration.Load();

            bool forceConfig = false;
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                forceConfig = Environment.GetCommandLineArgs()[1].Equals("--config");
            }

            if (!configuration.exist || forceConfig)
            {
                Console.WriteLine("Premier démarrage. Création d'un nouveau fichier de configuration...");

                string read;

                Console.Write("Nom d'hôte / adresse IP [localhost] : ");
                read = Console.ReadLine();
                if (read != "")
                {
                    configuration.values.listenIP = read;
                }
                else
                {
                    configuration.values.listenIP = "localhost";
                }

                Console.Write("N° de port [9090] : ");
                read = Console.ReadLine();
                if (read != "")
                {
                    configuration.values.listenPort = int.Parse(read);
                }
                else
                {
                    configuration.values.listenPort = 9090;
                }

                Console.Write("Nom de la base [Défaut] : ");
                read = Console.ReadLine();
                if (read != "")
                {
                    configuration.values.database = read;
                }
                else
                {
                    configuration.values.database = "Défaut";
                }

                Console.Write("Dossier racine [C:\\SharpGED\\] : ");
                read = Console.ReadLine();
                if (read != "")
                {
                    configuration.values.baseFolder = read;
                }
                else
                {
                    configuration.values.baseFolder = "C:\\SharpGED\\";
                }

                configuration.Save();
                Console.WriteLine();
            }

            List<WorkerThread> workers = new List<WorkerThread>();
            long currentWorkerId = 0;

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
