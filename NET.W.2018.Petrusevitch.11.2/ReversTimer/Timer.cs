namespace ReversTimer
{
    using System;
    using System.Threading;

    /// <summary>
    /// The timer class.
    /// </summary>
    public class Timer
    {
        private int second;

        /// <summary>
        /// The start timer event.
        /// </summary>
        public event EventHandler<TimerEventArgs> StartTimer;

        /// <summary>
        /// The end timer event.
        /// </summary>
        public event EventHandler<TimerEventArgs> TimerIsOver;

        public int Second
        {
            get => this.second;
            set
            {
                if (this.Second == 0)
                {
                    this.TimerIsOver?.Invoke(this, new TimerEventArgs($"Time is out", this.Second));
                    this.second = value;
                }

                this.second = value;
            }
        }

        /// <summary>
        /// Start timer.
        /// </summary>
        /// <param name="sec">
        /// Timein seconds.
        /// </param>
        public void Start(int sec)
        {
            if (sec > 0)
            {
                this.second = sec;
                while (this.Second >= 0)
                {
                    this.StartTimer?.Invoke(this, new TimerEventArgs($"You have {this.Second} second", this.Second));
                    Thread.Sleep(1000);
                    this.Second--;
                }
            }
            else
            {
                Console.WriteLine($"Time must over zero.");
            }
        }
    }
}
