using System.Collections.Generic;

namespace OpenB.BPME.Core.Test
{
    public class ParameterTypeMapper
    {
        IDictionary<string, ParameterType> parameterTypeMappings = new Dictionary<string, ParameterType>
        {
            { "INT", ParameterType.Integer },
            { "FLOAT", ParameterType.FloatingPoint },
            { "OPERATOR", ParameterType.ArithmeticOperator },
            { "SPACE", ParameterType.Whitespace },
            { "GREATER_THAN", ParameterType.EqualityComparer },
            { "EQUAL_TO", ParameterType.EqualityComparer },
            { "LOG_AND", ParameterType.LogicalOperator },
            { "LOG_OR", ParameterType.LogicalOperator },
            { "TRUE", ParameterType.Boolean },
            { "SYMBOL", ParameterType.Symbol },
            { "QUOTED_STRING", ParameterType.Text},
            { "SUB_EXPR_START", ParameterType.Structure},
            { "SUB_EXPR_END", ParameterType.Structure},

            // TODO: Evaluate fields before mapping. Remove this.
            { "FIELD", ParameterType.Field }
        };

        public ParameterType GetParameterType(string parameterType)
        {
            return parameterTypeMappings[parameterType];
        }
    }
}