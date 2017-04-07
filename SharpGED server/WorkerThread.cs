﻿using System.Threading;

namespace SharpGED_server
{

    class WorkerThread
    {

        private Worker worker;
        private Thread thread;

        public WorkerThread(long id)
        {
            worker = new Worker(id);
            thread = new Thread(worker.Run);
        }

        public Thread Thread { get => thread; set => thread = value; }
        public Worker Worker { get => worker; set => worker = value; }

    }
}
