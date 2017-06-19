﻿using SharpGED_server.Managers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SharpGED_server
{
    class Program
    {

        public static volatile bool _stopServer = false;
        public static ConfigurationManager configuration { get; set; }

        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            configuration = new ConfigurationManager();
            configuration.Load();

            bool forceConfig = false;
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                forceConfig = Environment.GetCommandLineArgs()[1].Equals("--config");
            }

            if (!configuration.exist || forceConfig)
            {
                FormConfiguration formConf = new FormConfiguration();
                if (formConf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            List<WorkerThread> workers = new List<WorkerThread>();
            long currentWorkerId = 0;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SharpGED server " + "v" + Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2) + "");
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
