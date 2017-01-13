using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using OpenB.Core;

namespace OpenB.BPM.Core
{    
    public class ProcessStateDefinition : DefinitionBase
    {
        [XmlArray]
        public List<EventDefinition> Events { get; set; }

        [XmlArray]
        public List<StateTransistionDefinition> Transitions { get; set; }

        public EventCollectionResult ExecuteEvents()
        {
            EventCollectionResult eventCollectionResult = new EventCollectionResult();

            foreach (EventDefinition eventDefinition in Events)
            {
                //  eventCollectionResult.EventResults.Add(eventDefinition.Execute());
            }

            return eventCollectionResult;
        }
    }
}