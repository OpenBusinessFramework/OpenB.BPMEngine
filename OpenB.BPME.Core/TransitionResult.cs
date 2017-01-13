namespace OpenB.BPM.Core
{

        public class TransitionResult
        {
            public RuleCollectionResult RuleCollectionResult { get; internal set; }
            public bool Success { get { return this.RuleCollectionResult.Success; } }
        }
}