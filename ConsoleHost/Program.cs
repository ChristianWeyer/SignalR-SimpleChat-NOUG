using Owin;
using System;
using Microsoft.Owin.Hosting;

namespace ConsoleHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://*:7777/push/"))
            {
                Console.WriteLine("Server running at http://*:7777/push/");
                Console.ReadLine();
            }            
        }
    }
}
