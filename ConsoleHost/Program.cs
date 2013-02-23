using Microsoft.Owin.Hosting;
using Owin;
using System;

namespace ConsoleHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapHubs();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApplication.Start<Startup>("http://*:7777/push/"))
            {
                Console.WriteLine("Server running at http://*:7777/push/");
                Console.ReadLine();
            }            
        }
    }
}
