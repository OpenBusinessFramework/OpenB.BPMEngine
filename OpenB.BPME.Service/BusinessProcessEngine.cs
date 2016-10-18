using OpenB.BPME.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            ProcessService service = new ProcessService();

        
        }

        protected override void OnStop()
        {
        }
    }
}
