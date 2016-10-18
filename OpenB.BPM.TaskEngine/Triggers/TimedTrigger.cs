using System;
using System.Timers;

namespace OpenB.BMP.TaskEngine.Triggers
{
    public class TimedTrigger<T> : ITrigger where T :  ITask, new()
    {
        private bool HasRun;

        public DateTime StartMoment { get; private set; }
        public TimeSpan Interval { get; private set; }
        public Timer Timer { get; private set; }
        public T Task { get; private set; }
        public bool RunOnlyOnce { get; private set; }

        public TimedTrigger(DateTime startMoment, TimeSpan interval, bool runOnlyOnce)
        {
            RunOnlyOnce = runOnlyOnce;
            Task = new T();

            Interval = interval;
            StartMoment = startMoment;  
            
        }

        public void Initialize()
        {
            Timer = new Timer(Interval.TotalMilliseconds);
            Timer.Elapsed += TimerElapsed;
            Timer.Enabled = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (e.SignalTime < StartMoment)
                return;

            if (RunOnlyOnce && HasRun)
            {
                return;
            }

            Timer.Enabled = false;
            IsRunning = true;

            RunTask();
            HasRun = true;

            IsRunning = false;
            Timer.Enabled = true;
        }

        public void RunTask()
        {
            Task.Run();
        }

        public void Check()
        {
            if (StartMoment <= DateTime.Now)
            {
                Timer.Start();
            }
        }

        public bool IsApplicable
        {
            get
            {
                return (!IsRunning && Timer.Enabled && Task.IsApplicable);

            }
        }

        public bool IsRunning
        {
            get; private set;
        }
    }
}