using System;
using System.Timers;

namespace Economics_Game
{
    public class TimeHandler
    {
        public int CurrentDay { get; set; }
        private readonly Timer _timer = new Timer();
        private readonly int _interval;

        public TimeHandler()
        {
            _interval = 30000;
            StartTime();
        }
        
        public void StartTime()
        {
            _timer.Interval = _interval;
            _timer.AutoReset = true;
            _timer.Elapsed += AddDay;
            _timer.Start();
        }

        private void AddDay(object sender, ElapsedEventArgs e)
        {
            CurrentDay++;
            Console.WriteLine($"day {CurrentDay}");
        }
    }
}