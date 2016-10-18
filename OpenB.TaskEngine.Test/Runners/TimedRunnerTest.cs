using NUnit.Framework;
using OpenB.BMP.TaskEngine.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenB.TaskEngine.Test.Runners
{
    [TestFixture]
    public class TimedRunnerTest
    {
        [Test]
        public void DoSomething()
        {
            TimedTrigger<SampleTask> timedRunner = new TimedTrigger<SampleTask>(DateTime.Now.AddSeconds(5), new TimeSpan(0, 0, 5), true);

            Thread.Sleep(5500);


        }

       
    }

    public class SampleTask : ITask
    {
        public bool IsApplicable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
