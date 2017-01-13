using System.Collections.Generic;
using System.Linq;

namespace OpenB.BPM.Core
{

        public class EventCollectionResult
        {
            public IList<EventResult> EventResults { get; private set; }
            public EventCollectionResult()
            {
                EventResults = new List<EventResult>();
            }

            public bool Success
            {
                get
                {
                    return EventResults.All(e => e.Success);
                }
            }
        }
}