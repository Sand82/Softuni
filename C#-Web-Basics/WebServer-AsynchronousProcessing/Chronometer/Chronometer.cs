﻿using System.Diagnostics;

namespace MyChronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        private List<string> laps;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.laps = new List<string>(); 
        }

        public string GetTime => this.stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => this.laps;

        public string Lap()
        {
            string result = GetTime;
            this.laps.Add(result);
            return result;
        }

        public void Reset()
        {
            this.stopwatch.Reset();
            this.laps.Clear();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}
