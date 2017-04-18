using System;
using System.Collections.Generic;
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

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[1], 9090));
            listener.Listen(10);

            Console.WriteLine("Prêt...");

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

            //Console.ReadKey(); // Pour le déboguage

        }

    }

}
