using Microsoft.Owin.Hosting;
using System;

namespace WebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:9000/");
            Console.Title = "WebAPI by Fizo";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO] {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} - WebAPI started !");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
