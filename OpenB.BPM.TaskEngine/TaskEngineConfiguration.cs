using OpenB.BMP.TaskEngine.Triggers;
using System.Collections.Generic;

namespace OpenB.BPM.TaskEngine
{
    public class TaskEngineConfiguration
    {
        public IList<ITrigger> Triggers { get; private set; }

        public TaskEngineConfiguration()
        {
            Triggers = new List<ITrigger>();
        }


    }
}