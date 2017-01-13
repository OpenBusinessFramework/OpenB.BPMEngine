using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;

namespace OpenB.BPM.Core
{
    public class ProcessService
    {
        private static ILog logger = LogManager.GetLogger("BusinessRule");


        IList<Process> runningInstances
        {
            get { return processDataService.GetRunningProcesses(); }

        }
        IProcessDataService processDataService;

        internal ProcessService(ProcessDataService processDataService)
        {
            if (processDataService == null)
                throw new ArgumentNullException(nameof(processDataService));
            this.processDataService = processDataService;
        }

        internal static ProcessService GetInstance()
        {
            ProcessServiceConfiguration configuration = ProcessServiceConfiguration.GetInstance();
            return new ProcessService( ProcessDataService.GetInstance());
        }

        internal Process StartProcess(string processDefinitionKey)
        {
            logger.Info($"Starting process {processDefinitionKey}");

            ProcessDefinition definition = processDataService.GetDefinition(processDefinitionKey);

            Process process = new Process(definition);
            process.CurrentState = new ProcessState(definition.StartingState);
            runningInstances.Add(process);
            logger.Info($"Process {processDefinitionKey} has been started.");

            return process;

        }
    }

    internal class ProcessServiceConfiguration
    {
        public string AssemblyFolder { get; set; }

        /// <summary>
        /// State change check interval in miliseconds.
        /// </summary>
        public int StateChangeCheckInterval { get; set; }

        internal static ProcessServiceConfiguration GetInstance()
        {
            var assemblyFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var configurationFilePath = Path.Combine(assemblyFolder, "configuration", "ProcessService.configuration.xml");

            XmlDocument configurationXml = new XmlDocument();
            configurationXml.Load(configurationFilePath);

            return ParseXml(configurationXml, assemblyFolder);
        }

        private static ProcessServiceConfiguration ParseXml(XmlDocument configurationXml, string assemblyFolder)
        {
            if (assemblyFolder == null)
                throw new ArgumentNullException(nameof(assemblyFolder));
            if (configurationXml == null)
                throw new ArgumentNullException(nameof(configurationXml));

            ProcessServiceConfiguration resultConfiguration = new ProcessServiceConfiguration();
            resultConfiguration.AssemblyFolder = Path.Combine(assemblyFolder, configurationXml.SelectSingleNode("/ProcessService/AssemblyFolder").InnerText);
            resultConfiguration.StateChangeCheckInterval = int.Parse(configurationXml.SelectSingleNode("/ProcessService/StateChangeCheckInterval").InnerText);

            return resultConfiguration;
        }
    }
}