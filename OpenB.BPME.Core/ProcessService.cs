using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using OpenB.BPM.Core;

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

        public IList<ProcessDefinition> GetActiveProcessDefinitions()
        {
            return processDataService.GetDefinitions();
        }

        public static ProcessService GetInstance()
        {
            ProcessServiceConfiguration configuration = ProcessServiceConfiguration.GetInstance();
            return new ProcessService(ProcessDataService.GetInstance());
        }

        public Process StartProcess(string processDefinitionKey)
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


            FileInfo configurationFileInfo = new FileInfo(configurationFilePath);
            if (configurationFileInfo.Directory.Exists)
            {
                configurationXml.Load(configurationFilePath);
                return ParseXml(configurationXml, assemblyFolder);
            }
            else
            {
                throw new XmlConfigurationException($"configuration folder ({configurationFileInfo.Directory.FullName}) not found.");
            }
        }

        private static string GetXmlValue(XmlDocument xmlDocument, string xPath)
        {
            var selectedXmlNode = xmlDocument.SelectSingleNode(xPath);

            if (selectedXmlNode == null)
            {

                throw new XmlConfigurationException($"Could not find {xPath}.");
            }

            return selectedXmlNode.InnerText;
        }

        private static ProcessServiceConfiguration ParseXml(XmlDocument configurationXml, string assemblyFolder)
        {
            if (assemblyFolder == null)
                throw new ArgumentNullException(nameof(assemblyFolder));
            if (configurationXml == null)
                throw new ArgumentNullException(nameof(configurationXml));

            ProcessServiceConfiguration resultConfiguration = new ProcessServiceConfiguration();

            var assemblyFolderName = GetXmlValue(configurationXml, "/ProcessServiceConfiguration/AssemblyFolder");


            resultConfiguration.AssemblyFolder = assemblyFolderName;

            var stateChangeCheckInterval = GetXmlValue(configurationXml, "/ProcessServiceConfiguration/StateChangeCheckInterval");


            resultConfiguration.StateChangeCheckInterval = int.Parse(stateChangeCheckInterval);

            return resultConfiguration;
        }
    }
}