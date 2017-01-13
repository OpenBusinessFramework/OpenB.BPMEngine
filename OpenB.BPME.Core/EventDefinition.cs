using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenB.BPM.Core
{

    public class EventDefinition
    {
        public int Sequence { get; set; }
        public string EventKey { get; set; }

        [XmlArray]
        public List<EventDefinitionParameter> Parameters { get; set; }
    }
}