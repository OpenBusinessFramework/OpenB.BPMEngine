using System.Collections.Generic;

namespace OpenB.BPM.Core
{

        internal interface IProcessDataService
        {
            ProcessDefinition GetDefinition(string processDefinitionKey);
            IList<Process> GetRunningProcesses();
        }
}