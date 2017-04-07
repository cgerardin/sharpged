using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SharpGED_server
{
    class Program
    {
        static void Main(string[] args)
        {

            List<WorkerThread> workers = new List<WorkerThread>();
            long currentWorkerId = 1;

            Console.WriteLine("*** SharpGED server ***");

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0], 8080));
            listener.Listen(10);

            Console.WriteLine("Prêt...");

            while (true)
            {

                Socket h = listener.Accept();

                workers.Add(new WorkerThread(currentWorkerId));
                workers.Last().Thread.Start();
                while (!workers.Last().Thread.IsAlive);

                workers.Last().Worker.Handler = h;
                currentWorkerId++;

            }

            Console.WriteLine("Clôture de toutes les connexions...");

            foreach (WorkerThread currentWorker in workers)
            {
                currentWorker.Worker.RequestStop();
                currentWorker.Thread.Join();
            }

            Console.WriteLine("Terminé.");

        }

        public void GetKey()
        {
            Console.WriteLine("GetKey !");
        }

    }

}
