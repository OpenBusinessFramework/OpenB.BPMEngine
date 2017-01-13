using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace OpenB.BPM.Core
{
    [XmlRoot(Namespace = "http://www.openb.org/schemas/bpm/process")]
    public class ProcessDefinition : DefinitionBase, IXmlConfiguration
    {
        [XmlArray(IsNullable = false)]
        public List<ProcessStateDefinition> ProcessStateDefinitions { get; set; }

        [XmlIgnore]
        public ProcessStateDefinition StartingState
        {
            get
            {
                return ProcessStateDefinitions.Single(psd => psd.Key == StartingStateReference.Ref);
            }
        }

        [XmlElement("StartingState", IsNullable = false)]
        public ProcessStateDefinitionReference StartingStateReference { get; set; }
    }

    public class ProcessStateDefinitionReference
    {
        [XmlAttribute]
        public string Ref { get; set; }
    }
}