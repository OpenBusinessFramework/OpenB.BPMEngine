using OpenB.DSL;

namespace OpenB.BPM.Core
{
    public class RuleResult
    {
        public bool Success { get; private set; }

        internal static RuleResult ParseFrom(ParserResult parserResult)
        {
            if (parserResult == null)
                throw new System.ArgumentNullException(nameof(parserResult));
            RuleResult result = new RuleResult();
            result.Success = (bool)parserResult.CompiledExpression.Evaluate();

            return result;
        }
    }
}