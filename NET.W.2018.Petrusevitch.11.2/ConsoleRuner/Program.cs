using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRuner
{
    using ReversTimer;

    class Program
    {
        static void Main(string[] args)
        {
            ReversTimer.Timer reversTimer = new Timer();
            reversTimer.StartTimer += ShowMessage;
            reversTimer.TimerIsOver += SubscriberOne.SubscriberMessage;

            reversTimer.Start(10);

            Console.ReadLine();
        }

        /// <summary>
        /// The show message from event subscriber.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The timer data.
        /// </param>
        private static void ShowMessage(object sender, TimerEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
