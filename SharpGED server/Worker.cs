using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SharpGED_server
{
    class Worker
    {

        private volatile bool _shouldStop;
        private long id;
        private Socket handler;

        public long Id { get => id; set => id = value; }
        public Socket Handler { get => handler; set => handler = value; }

        public Worker(long id)
        {
            Id = id;
        }

        public void Run()
        {

            byte[] bytes = new byte[1024];
            string cmd;

            Console.WriteLine("[" + id + "] Client " + ((IPEndPoint)Handler.RemoteEndPoint).Address + " connecté");

            while (!_shouldStop)
            {

                if (Handler.Available > 0)
                {

                    Handler.Receive(bytes);
                    cmd = Encoding.Default.GetString(bytes).TrimEnd('\0');
                    bytes = new byte[1024];

                    if (!cmd.Equals(""))
                    {
                        switch (cmd)
                        {

                            case "ELO":
                                Console.WriteLine("[" + id + "] Bonjour !");
                                break;

                            case "GET":
                                Console.WriteLine("[" + id + "] Envoi fichier...");

                                string uri = ConfigurationManager.AppSettings.Get("BaseFolder").ToString();
                                uri += "storage\\test.pdf";

                                FileStream inStream = File.OpenRead(uri);

                                Handler.Send(Encoding.ASCII.GetBytes(inStream.Length.ToString()));

                                byte[] fileBytes = new byte[inStream.Length];
                                inStream.Read(fileBytes, 0, (int)inStream.Length);
                                inStream.Close();

                                Handler.Send(fileBytes);

                                break;

                            case "BYE":
                                RequestStop();
                                break;

                            case "STOPSERVER":
                                Console.WriteLine("[" + id + "] Requête d'arrêt du serveur");
                                Program._stopServer = true;
                                RequestStop();
                                break;

                            default:
                                Console.WriteLine("[" + id + "] Commande inconnue : " + cmd);
                                break;

                        }
                    }

                }

            }

            Handler.Shutdown(SocketShutdown.Both);
            Handler.Close();
            Console.WriteLine("[" + id + "] Client déconnecté.");

        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
