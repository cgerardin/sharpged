using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Sockets;

namespace SharpGED_server
{
    class Program
    {

        public static volatile bool _stopServer = false;

        static void Main(string[] args)
        {

            List<WorkerThread> workers = new List<WorkerThread>();
            long currentWorkerId = 0;

            Console.WriteLine("*** SharpGED server ***");
            
            string listenIP_string = Properties.Settings.Default.ListenIP;
            int listenPort = Properties.Settings.Default.ListenPort;

            IPAddress listenIP = null;
            if(listenIP_string.Equals("localhost") || listenIP_string.Equals("127.0.0.1") )
            {
                listenIP = IPAddress.Loopback;
            } else if(!IPAddress.TryParse(listenIP_string, out listenIP))
            {
                listenIP = Dns.GetHostAddresses(listenIP_string)[0];
            }

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(listenIP, listenPort));
            listener.Listen(10);

            Console.WriteLine("En écoute à l'adresse " + listenIP_string + ":" + listenPort + " ...");

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
