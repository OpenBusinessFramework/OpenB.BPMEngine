using System;

namespace OpenB.BPM.Core
{
    public class ProcessStateChange
    {
        public DateTime Moment { get; private set; }
        public ProcessState PreviousState { get; private set; }
        public ProcessState NewState { get; private set; }

        public ProcessStateChange(ProcessState previousState, ProcessState newState)
        {
            NewState = newState;
            PreviousState = previousState;
            if (newState == null)
                throw new ArgumentNullException(nameof(newState));
            if (previousState == null)
                throw new ArgumentNullException(nameof(previousState));

            Moment = DateTime.Now;
        }
    }
}