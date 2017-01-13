using OpenB.BPM.TaskEngine.Triggers;
using System;

namespace OpenB.BPM.TaskEngine
{
    public class TaskEngine
    {
        public TaskEngineConfiguration Configuration { get; set; }

        public TaskEngine(TaskEngineConfiguration configuration)
        {
            Configuration = configuration;

            if (configuration == null)
                throw new System.ArgumentNullException(nameof(configuration));
        }

        public void Initialize()
        {
            foreach(ITrigger trigger in Configuration.Triggers)
            {
                trigger.Initialize();
            }
        }

        public static TaskEngine GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}
