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

        public const int PACKET_SIZE = 1024;

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

            byte[] buffer = new byte[1024];
            string order;
            string cmd;
            string arg;
            int argpos;

            Console.WriteLine("[" + id + "] Client " + ((IPEndPoint)Handler.RemoteEndPoint).Address + " connecté");

            while (!_shouldStop)
            {

                if (Handler.Available > 0)
                {
                    // Récupère l'ordre envoyé par le client, et vide le buffer
                    Handler.Receive(buffer);
                    order = Encoding.Default.GetString(buffer).TrimEnd('\0');
                    buffer = new byte[1024];

                    if (!order.Equals(""))
                    {
                        // Sépare la commande et son/ses éventuel(s) argument(s)
                        argpos = order.IndexOf(' ');
                        if (argpos == -1)
                        {
                            cmd = order;
                            arg = "";
                        }
                        else
                        {
                            cmd = order.Substring(0, argpos);
                            arg = order.Substring(argpos + 1);
                        }

                        // Traitement en fonction de la commande reçue
                        switch (cmd)
                        {

                            case "ELO": // Dis bonjour (pour le déboguage)
                                Console.WriteLine("[" + id + "] Bonjour !");
                                break;

                            case "GET": // Envoie le fichier spécifié en argument
                                Console.WriteLine("[" + id + "] Envoi de '" + arg + "'...");

                                string uri = ConfigurationManager.AppSettings.Get("BaseFolder").ToString();
                                uri += "storage\\" + arg;
                                FileStream inStream = File.OpenRead(uri);

                                // Envoie la taille exacte du fichier
                                int size = (int)inStream.Length;
                                Handler.Send(Encoding.ASCII.GetBytes(size.ToString()));

                                // Copie l'intégralité du fichier dans un tableau
                                byte[] fileBytes = new byte[size];
                                inStream.Read(fileBytes, 0, size);
                                inStream.Close();

                                Console.WriteLine("[" + id + "] (en " + size / PACKET_SIZE + " paquets de " + PACKET_SIZE + " octets)");

                                // Envoie le tableau par paquets de 1024 octets
                                byte[] filePacket;
                                for (int i = 0; i < size; i += PACKET_SIZE)
                                {
                                    filePacket = new byte[PACKET_SIZE];

                                    if (i + PACKET_SIZE <= size)
                                    {
                                        Buffer.BlockCopy(fileBytes, i, filePacket, 0, PACKET_SIZE);
                                    }
                                    else
                                    {
                                        Buffer.BlockCopy(fileBytes, i, filePacket, 0, size - i);
                                    }

                                    Handler.Send(filePacket);
                                }
                                Console.WriteLine("[" + id + "] Terminé.");

                                break;

                            case "BYE": // Déconnecte le client
                                RequestStop();
                                break;

                            case "STOP": // Arrête le serveur
                                Console.WriteLine("[" + id + "] Requête d'arrêt du serveur");
                                Program._stopServer = true;
                                RequestStop();
                                break;

                            default:
                                Console.WriteLine("[" + id + "] Commande inconnue : " + order);
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
