using OpenB.BPM.TaskEngine.Triggers;
using System;
using System.Collections.Generic;
using System.Xml;

namespace OpenB.BPM.TaskEngine
{
    public class TaskEngineConfiguration
    {       
        public IList<ITrigger> Triggers { get; private set; }

        public TaskEngineConfiguration()
        {
            Triggers = new List<ITrigger>();
        }

        public TaskEngineConfiguration(XmlDocument xmlConfiguration)
        {
            if (xmlConfiguration == null)
                throw new System.ArgumentNullException(nameof(xmlConfiguration));


            throw new NotImplementedException();
        }

        public static TaskEngineConfiguration GetInstance(string configurationFile)
        {
            System.Xml.XmlDocument xmlConfiguration = new System.Xml.XmlDocument();
            xmlConfiguration.Load(configurationFile);

            return new TaskEngineConfiguration(xmlConfiguration);
        }
    }
}