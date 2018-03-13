using System;
using System.Net.Sockets;
using System.Text;

namespace SharpGED_lib_core
{
    public static class TransfertManager
    {

        public const int PACKET_SIZE = 1024;

        // Envoie la taille puis les données
        public static void Send(byte[] data, Socket receiver)
        {
            byte[] buffer = new byte[PACKET_SIZE];

            // Envoie la taille de l'objet
            receiver.Send(BitConverter.GetBytes(data.Length));

            // Attend la confirmation
            receiver.Receive(buffer);

            // Envoie l'objet
            receiver.Send(data);

            // Attend la confirmation
            receiver.Receive(buffer);
        }

        // Récupère la taille puis les données
        public static byte[] Recive(Socket transmitter)
        {
            // Récupère la taille de l'objet
            byte[] buffer = new byte[sizeof(Int32)];
            transmitter.Receive(buffer);
            int objectSize = BitConverter.ToInt32(buffer, 0);

            // Envoie la confirmation
            transmitter.Send(Encoding.Unicode.GetBytes("OK"));

            // Récupère l'objet
            byte[] objectBytes = new byte[objectSize];
            int bytesReceived;
            int bytesTotal = 0;
            int bytesLeft = objectSize;

            while (bytesTotal < objectSize)
            {
                bytesReceived = transmitter.Receive(objectBytes, bytesTotal, bytesLeft, SocketFlags.None);
                if (bytesReceived == 0)
                {
                    objectBytes = null;
                    break;
                }
                bytesTotal += bytesReceived;
                bytesLeft -= bytesReceived;
            }

            // Envoie la confirmation
            transmitter.Send(Encoding.Unicode.GetBytes("OK"));

            return objectBytes;
        }

    }
}
