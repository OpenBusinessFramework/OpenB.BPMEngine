using System;
using System.Collections.Generic;
using System.IO;

namespace OpenB.BPM.Core
{

    public class XmlConfigurationManager
    {
        IDictionary<Type, IXmlConfiguration> cachedConfigurations;

        readonly XmlConfigurationService xmlConfigurationService;

        public XmlConfigurationManager(XmlConfigurationService xmlConfigurationService)
        {
            this.xmlConfigurationService = xmlConfigurationService;
            if (xmlConfigurationService == null)
                throw new ArgumentNullException(nameof(xmlConfigurationService));

            cachedConfigurations = new Dictionary<Type, IXmlConfiguration>();
        }

        public IList<T> GetConfigurations<T>() where T : IXmlConfiguration
        {
            // TODO: Caching

            IList<T> resultConfigurations = new List<T>();
            
            var configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "Processes");
            var configurationDirectory = new DirectoryInfo(configurationPath);

            foreach (FileInfo file in configurationDirectory.GetFiles("*.processdefinition.xml"))
            {
                var configuration = xmlConfigurationService.ReadConfiguration<T>(file.FullName);
                resultConfigurations.Add(configuration);
            }

            return resultConfigurations;

        }

        public static XmlConfigurationManager GetInstance()
        {
            return new XmlConfigurationManager(new XmlConfigurationService());
        }
    }
}