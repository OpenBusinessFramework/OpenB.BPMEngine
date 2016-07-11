using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BPME.Core
{
    public class ProcessDefinition
    {
        public IEnumerable<ProcessStep> Steps { get; set; }
        public void Execute(ProcessExecutionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
        }
    }

    public class ProcessStep
    {
        public IProcessExpression EntryCriteria { get; set; }
    }
}
