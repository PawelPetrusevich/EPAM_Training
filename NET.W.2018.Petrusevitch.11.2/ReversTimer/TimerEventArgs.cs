// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" TimerEventArgs.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ReversTimer
//  Project: ReversTimer
//  Filename: TimerEventArgs.cs
//  Created day: 15.04.2018    12:00
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ReversTimer
{
    using System;

    /// <summary>
    /// The timer event args.
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(string mess, int second)
        {
            this.Message = mess;
            this.Second = second;
        }

        /// <summary>
        /// Gets or sets the message about timer.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets time in timer.
        /// </summary>
        public int Second { get; set; }

    }
}