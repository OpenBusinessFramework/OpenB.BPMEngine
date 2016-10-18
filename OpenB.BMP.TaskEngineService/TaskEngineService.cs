using System.ServiceProcess;

namespace OpenB.BPM.TaskEngineService
{
    public partial class TaskEngineService : ServiceBase
    {
        public TaskEngineService()
        {
          //  InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
