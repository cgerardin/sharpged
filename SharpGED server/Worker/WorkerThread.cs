using System.Net.Sockets;
using System.Threading;

namespace SharpGED_server
{

    class WorkerThread
    {

        private Worker worker;
        private Thread thread;

        public WorkerThread(long id, Socket handler)
        {

            if (!Program._stopServer)
            {
                Worker = new Worker(id);
                Thread = new Thread(Worker.Run);
                Thread.Start();
                while (!Thread.IsAlive) ;

                handler.Blocking = true;
                Worker.Handler = handler;
            }

        }

        public Thread Thread { get => thread; set => thread = value; }
        public Worker Worker { get => worker; set => worker = value; }

    }
}
