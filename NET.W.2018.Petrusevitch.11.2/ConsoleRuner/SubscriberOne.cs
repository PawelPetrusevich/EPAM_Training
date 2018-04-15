// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" SubscriberOne.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ReversTimer
//  Project: ConsoleRuner
//  Filename: SubscriberOne.cs
//  Created day: 15.04.2018    13:01
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ConsoleRuner
{
    using System;

    using ReversTimer;

    /// <summary>
    /// The subscriber class.
    /// </summary>
    public class SubscriberOne
    {
        /// <summary>
        /// The subscriber message.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The information about timer.
        /// </param>
        public static void SubscriberMessage(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Subscriber one has notification: {e.Message}");
        }
    }
}