using System.Collections.Generic;
using System.Linq;

namespace OpenB.BPM.Core
{

        public class RuleCollectionResult
        {
            internal IList<RuleResult> RuleResults { get; private set; }

            public RuleCollectionResult()
            {
                RuleResults = new List<RuleResult>();
            }

            public bool Success
            {
                get
                {
                    return RuleResults.All(t => t.Success);
                }
            }
        }
}