using log4net;
using OpenB.Core.ACL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.BPME.Core
{
    public class ProcessService
    {
        private static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ProcessService()
        {

        }

        public void StartProcess(ProcessDefinition processDefinition, User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (processDefinition == null)
                throw new ArgumentNullException(nameof(processDefinition));

            ProcessExecutionContext executionContext = new ProcessExecutionContext(processDefinition);

          
        }
    }
}
