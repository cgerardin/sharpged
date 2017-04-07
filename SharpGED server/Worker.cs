using System;
using System.Threading;

namespace SharpGED_server
{
    class Worker
    {

        private volatile bool _shouldStop;
        private String name;

        public Worker(String name)
        {
            this.name = name;
        }

        public void Run()
        {
            while (!_shouldStop)
            {
                Thread.Sleep(100);
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
