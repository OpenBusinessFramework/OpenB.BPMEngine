using System;

namespace OpenB.BPME.Core
{
    public class ProcessExecutionContext
    {
        readonly ProcessDefinition processDefinition;

        public ProcessExecutionContext(ProcessDefinition processDefinition)
        {
            if (processDefinition == null)
                throw new System.ArgumentNullException(nameof(processDefinition));

            this.processDefinition = processDefinition;         
        }
    }
}