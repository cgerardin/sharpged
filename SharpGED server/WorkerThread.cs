using System;
using System.Threading;

namespace SharpGED_server
{

    class WorkerThread
    {

        Worker worker;
        Thread thread;

        public WorkerThread(String name)
        {
            worker = new Worker(name);
            thread = new Thread(worker.Run);
        }

        public Thread Thread { get => thread; set => thread = value; }
        internal Worker Worker { get => worker; set => worker = value; }

    }
}
