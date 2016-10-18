using System.Collections.Generic;

namespace OpenB.BPME.Core
{
    public interface IProcessExpression
    {
        IEnumerable<IProcessExpression> SubExpressions { get; }
        bool Evaluate();
    }   
}