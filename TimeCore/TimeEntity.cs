using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace TimeCore
{
    public class TimeEntity
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Title { get; set; }
        public TimeSpan Elapsed => IsRunning ? DateTime.Now - StartTime : EndTime - StartTime;
            /*(EndTime >= StartTime) ? EndTime - StartTime : DateTime.Now.TimeOfDay;*/
        public int ElapsedMinutes => (int)Elapsed.TotalMinutes;
        public bool IsRunning => isSet(StartTime) && !isSet(EndTime);

        public TimeEntity()
        {
            StartTime = DateTime.MinValue;
            Title = "";
        }

        public void StartOrResume()
        {
            StartTime = StartTime > DateTime.MinValue ? StartTime : DateTime.Now;
            EndTime = DateTime.MinValue;
        }

        public void Stop()
        {
            EndTime = DateTime.Now;
        }

        private bool isSet(DateTime dateTime)
        {
            return dateTime > DateTime.MinValue;
        }
    }
}
