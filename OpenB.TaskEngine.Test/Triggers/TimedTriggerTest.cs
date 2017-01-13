using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml;
using System.Collections.Generic;
using OpenB.BPM.TaskEngine.Triggers;
using OpenB.BPM.TaskEngine.Tasks;

namespace OpenB.TaskEngine.Test.Triggers
{
    [TestFixture]
    public class TimedTriggerTest
    {
        [Test]
        public void TimedTrigger_TimeIsElapsed_TaskHasRun()
        {           
            Mock<TimedTrigger<SampleTask>> timedRunner = new Mock<TimedTrigger<SampleTask>>(DateTime.Now.AddSeconds(5), new TimeSpan(0, 0, 5), true);
            timedRunner.Object.Initialize();

            Thread.Sleep(5500);

            Assert.That(timedRunner.Object.Task.Counter == 1);
        }

        [Test]
        public void TimedTrigger_TimeIsNotElapsed_TaskHasNotRun()
        {

            Mock<TimedTrigger<SampleTask>> timedRunner = new Mock<TimedTrigger<SampleTask>>(DateTime.Now.AddSeconds(5), new TimeSpan(0, 0, 5), true);
            timedRunner.Object.Initialize();          

            Assert.That(timedRunner.Object.Task.Counter == 0);
        }

        [Test]
        public void DoSomething()
        {
            Type timedTriggerType = typeof(TimedTrigger<>);
            
           
            var result =  GetConstructor(timedTriggerType, new[] {  "endMoment", "interval", "runOnlyOnce" });

        }

        [Test]
        public void DoSomethingElse()
        {
            Type timedTriggerType = typeof(TimedTrigger<>);
            string configFilePath = @"E:\Downloads\Projects\Projects\Personal\OpenB.BPMEngine\OpenB.TaskEngine.Test\Configuration\BaseConfiguration.TaskEngine.xml";

            XmlDocument configDocument = new XmlDocument();
            configDocument.Load(configFilePath);

            XmlNode triggerNode = configDocument.SelectSingleNode("//TimedTrigger");

            var result = GetConstructor(triggerNode);

        }

        public ConstructorInfo GetConstructor(XmlNode node)
        {
            Assembly assembly = Assembly.Load("OpenB.BPM.TaskEngine");
            Type classType = assembly.GetType("OpenB.BPM.TaskEngine.Triggers." + node.LocalName, true);
            Type taskType =  Type.GetType(node.Attributes["Task"].Value);

            return GetConstructor(classType, node.ChildNodes);
        }

        public ConstructorInfo GetConstructor(Type type, XmlNodeList xmlNodes)
        {
            IList<string> paramList = new List<string>();

            foreach(XmlNode xmlNode in xmlNodes)
            {
                paramList.Add(xmlNode.LocalName);
            }

            return GetConstructor(type, paramList.ToArray());
        }

        public ConstructorInfo GetConstructor(Type type, string[] parameterNames)
        {
            if (parameterNames == null)
                throw new ArgumentNullException(nameof(parameterNames));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.GetConstructors().Where(c => c.GetParameters().All(p => parameterNames.Contains(p.Name, new LowerStringComparer()))).Single();
        }
    }

    internal class LowerStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToLower().Equals(y.ToLower());
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

    public class SampleTask : ITask
    {
        public int Counter = 0;

        public bool IsApplicable
        {
            get
            {
                return true;
            }
        }

        public void Run()
        {
            Counter++;
        }
    }
}
