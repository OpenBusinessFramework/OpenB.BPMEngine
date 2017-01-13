using System;
using System.Collections.Generic;

namespace OpenB.BPM.Core
{
        public class StateTransistionDefinition
        {
            public List<BusinessRuleDefinition> BusinessRules { get; set; }
            public ProcessStateDefinition ResultingStateDefinition { get;  set; }            
        }
}