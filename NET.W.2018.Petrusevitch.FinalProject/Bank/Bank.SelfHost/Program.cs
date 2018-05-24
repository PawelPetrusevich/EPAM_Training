using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.SelfHost
{
    using Microsoft.Owin.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Bank.MVC.Startup>("http://localhost:8000/"))
            {
                Console.WriteLine("Server Run");
                Console.ReadLine();
            }
        }
    }
}
