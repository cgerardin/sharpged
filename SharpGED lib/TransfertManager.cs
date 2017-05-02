using System;
using System.Net.Sockets;
using System.Text;

namespace SharpGED_lib
{
    public static class TransfertManager
    {

        // Envoie la taille puis les données
        public static void Send(byte[] data, Socket receiver)
        {
            byte[] buffer = new byte[8];
            buffer = BitConverter.GetBytes(data.Length);
            receiver.Send(buffer);
            System.Threading.Thread.Sleep(1000);
            receiver.Send(data);
        }

        // Récupère la taille puis les données
        public static byte[] Recive(Socket transmitter)
        {
            // Récupère la taille de l'objet
            byte[] buffer = new byte[8];
            transmitter.Receive(buffer);
            int objectSize = BitConverter.ToInt32(buffer, 0);

            System.Threading.Thread.Sleep(1000);

            // Récupère l'objet et le dé-sérialise
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

            return objectBytes;
        }

    }
}
