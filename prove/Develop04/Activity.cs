using System;
using System.IO;
using System.Threading;

namespace MindfulnessProgram
{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;
        private static readonly string _logFile = "activity_log.txt";
        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        protected Random _rand = new Random();

        protected int DurationSeconds
        {
            get => _durationSeconds;
            set => _durationSeconds = Math.Max(0, value);
        }

        public virtual void Start()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---\n");
            Console.WriteLine(_description);
            Console.Write("\nEnter duration in seconds: ");
            if (!int.TryParse(Console.ReadLine(), out int seconds))
                seconds = 0;
            DurationSeconds = seconds;
            Console.WriteLine("\nGet ready...");
            PauseWithSpinner(3);
        }

        public virtual void End()
        {
            Console.WriteLine("\nWell done!");
            PauseWithSpinner(2);
            Console.WriteLine($"You completed the {_name} for {DurationSeconds} seconds.");
            PauseWithSpinner(3);
            LogActivity();
        }

        protected void PauseWithSpinner(int seconds)
        {
            char[] spinner = { '|', '/', '-', '\\' };
            DateTime start = DateTime.Now;
            int i = 0;
            while ((DateTime.Now - start).TotalSeconds < seconds)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(300);
                Console.Write("\b \b");
                i++;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        protected bool TimeRemaining(DateTime endTime) => DateTime.Now < endTime;

        private void LogActivity()
        {
            try
            {
                string log = $"{DateTime.Now:u} | {_name} | Duration: {_durationSeconds}s";
                File.AppendAllText(_logFile, log + Environment.NewLine);
            }
            catch { }
        }

        public virtual void Run() { }
    }
}
