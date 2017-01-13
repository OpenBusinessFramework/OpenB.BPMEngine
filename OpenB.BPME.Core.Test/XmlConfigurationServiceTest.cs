using System;
using System.IO;
using NUnit.Framework;

namespace OpenB.DSL.Test
{
    [TestFixture]
    public class XmlConfigurationServiceTest
    {
        [Test]
        public void DoSomething()
        {
            XmlConfigurationService xmlConfigurationService = new XmlConfigurationService();

            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "processes",  "sample.processdefinition.xml");

            xmlConfigurationService.ReadConfiguration<ProcessDefinition>(fullPath);
        }


    }
}
