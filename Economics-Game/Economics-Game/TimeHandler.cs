using System;
using System.Timers;

namespace Economics_Game
{
    public class TimeHandler
    {
        public int CurrentDay { get; set; }
        public int DayProgress { get; set; }
        private readonly Timer _timer = new Timer();
        private readonly int _interval;

        public TimeHandler()
        {
            CurrentDay = 1;
            _interval = 1000;
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
            //Day Progress allows program to get progress bar count
            DayProgress++;
            if (DayProgress == 30)
            {
                CurrentDay++;
                DayProgress = 0;
            }
        }
    }
}