using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace EXO3
{
    class ServerExo3
    {
        [Obsolete]
        static void Main(string[] args)
        {

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0);
            };

            TcpListener ServerSocket = new TcpListener(5000);
            ServerSocket.Start();

            Console.WriteLine("Server started.");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                handleClient client = new handleClient();
                client.startClient(clientSocket);
            }


        }
    }

    public class handleClient
    {
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Echo);
            ctThread.Start();
        }

        private static int incr(int param1)
        {
            param1 = param1 + 1;
            return param1;
        }

        private void Echo()
        {

            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {     
                string request = reader.ReadString(); // GET /uri?nbr=1 HTTP/1.1
                string[] requestSplit = request.Split(' ');
                string method = requestSplit[0];

                if (method == "GET")
                {
                    string uri = requestSplit[1];
                    string parameters = uri.Substring(uri.IndexOf('?') + 1);
                    string nbr = HttpUtility.ParseQueryString(parameters).Get("nbr");

                    int increment = incr(int.Parse(nbr));
                    writer.Write("Response "+increment.ToString()); //ici on retourne la valeur incrémentée sous le format : Response : increment
                }
                else
                {
                    Console.WriteLine("Method not supported");
                }
            }
        }
    }
}