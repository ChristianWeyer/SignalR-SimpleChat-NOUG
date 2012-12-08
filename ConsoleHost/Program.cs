using System;
using Microsoft.AspNet.SignalR.Hosting.Self;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://*:7777/push/";

            var server = new Server(url);
            server.MapHubs();
            server.Start();

            Console.WriteLine("Listening on {0}", url);

            Console.ReadLine();

            server.Stop();
        }
    }
}
