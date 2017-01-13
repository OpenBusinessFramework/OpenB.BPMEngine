using System;

namespace OpenB.BPM.Core
{

        public class ProcessState
        {
            public ProcessStateDefinition ProcessStateDefinition { get; private set; }

            public ProcessState(ProcessStateDefinition processStateDefinition)
            {
                if (processStateDefinition == null)
                    throw new ArgumentNullException(nameof(processStateDefinition));

                this.ProcessStateDefinition = processStateDefinition;
            }
        }
}