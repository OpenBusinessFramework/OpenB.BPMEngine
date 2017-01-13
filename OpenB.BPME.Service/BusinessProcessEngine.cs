using OpenB.BPM.Core;
using System.ServiceProcess;

namespace OpenB.BPME.Service
{
    public partial class BusinessProcessEngine : ServiceBase
    {
        public BusinessProcessEngine()
        {
            InitializeComponent();            
        }      

        protected override void OnStart(string[] args)
        {
           

        
        }

        protected override void OnStop()
        {
        }
    }
}
