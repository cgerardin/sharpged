using System;
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
            int separator;
            string cmd;
            string[] argv;

            Console.WriteLine("[" + id + "] Client " + ((IPEndPoint)handler.RemoteEndPoint).Address + " connecté");

            DatabaseManager database = new DatabaseManager();
            StorageManager storage = new StorageManager(handler);

            while (!_shouldStop)
            {

                if (handler.Available > 0)
                {
                    // Récupère l'ordre envoyé par le client, et vide le buffer
                    handler.Receive(buffer);
                    order = Encoding.Default.GetString(buffer).TrimEnd('\0');
                    buffer = new byte[1024];

                    if (!order.Equals(""))
                    {
                        // Sépare la commande et son/ses éventuel(s) argument(s)
                        separator = order.IndexOf(' ');
                        if (separator == -1)
                        {
                            cmd = order;
                            argv = new string[0];
                        }
                        else
                        {
                            cmd = order.Substring(0, separator);
                            argv = order.Substring(separator + 1).Split(';');
                        }

                        // Traitement en fonction de la commande reçue
                        switch (cmd)
                        {

                            case "ELO": // Dis bonjour (pour le déboguage)
                                Console.WriteLine("[" + id + "] Bonjour !");
                                break;

                            case "BYE": // Déconnecte le client
                                RequestStop();
                                break;

                            case "STOP": // Arrête le serveur
                                Console.WriteLine("[" + id + "] Requête d'arrêt du serveur");
                                Program._stopServer = true;
                                RequestStop();
                                break;

                            case "INIT": // Initialise une nouvelle base de données
                                Console.WriteLine("[" + id + "] Création de la base de données...");
                                database.Initialize();
                                Console.WriteLine("[" + id + "] Terminé.");
                                break;

                            case "GET": // Envoie le fichier spécifié en argument
                                Console.WriteLine("[" + id + "] Envoi de '" + argv[0] + "'...");
                                storage.Send(argv[0]);
                                Console.WriteLine("[" + id + "] Terminé.");
                                break;

                            case "PUT": // Insère un fichier dans la base
                                Console.WriteLine("[" + id + "] Réception du fichier '" + argv[0] + "'...");
                                storage.Recive(argv[0]);
                                Console.WriteLine("[" + id + "] Terminé.");
                                break;

                            case "LIST": // Envoie la liste les fichiers
                                Console.WriteLine("[" + id + "] Envoi de la liste des fichiers");
                                storage.List();
                                break;

                            default:
                                Console.WriteLine("[" + id + "] Commande inconnue : " + order);
                                break;

                        }
                    }

                }

            }

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            Console.WriteLine("[" + id + "] Client déconnecté.");

        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

    }
}
