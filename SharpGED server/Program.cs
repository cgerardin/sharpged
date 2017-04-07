using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGED_server
{
    class Program
    {
        static void Main(string[] args)
        {

            List<WorkerThread> workers = new List<WorkerThread>();
            char name = 'A';

            Console.WriteLine("Ready...");

            bool running = true;
            while (running)
            {

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.N:
                        
                        Console.WriteLine("- Creating new worker '" + name + "'.");
                        workers.Add(new WorkerThread(name.ToString()));
                        workers.Last().Thread.Start();
                        while (!workers.Last().Thread.IsAlive) ;
                        name++;
                        break;

                    case ConsoleKey.Escape:

                        running = false;
                        break;

                }

            }

            Console.Write("Terminating all actives workers... ");

            foreach (WorkerThread currentWorker in workers)
            {
                currentWorker.Worker.RequestStop();
                currentWorker.Thread.Join();
            }

            Console.WriteLine("Done.");

            Console.ReadKey();

        }
    }
}
