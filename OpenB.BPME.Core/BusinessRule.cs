using System;
using log4net;
using OpenB.DSL;
using OpenB.DSL.Reflection;

namespace OpenB.BPM.Core
{
    public class BusinessRule : IRule
    {
        private static ILog logger = LogManager.GetLogger("BusinessRule"); 

        public EvaluationContext Context { get; private set; }
        public string RuleExpression { get; private set; }
        public IParser Parser { get; private set; }
        public ProcessEngineConfiguration Configuration { get; private set; }

        public BusinessRule(ProcessEngineConfiguration configuration, IParser parser, EvaluationContext context, string ruleExpression)
        {           
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));
            if (ruleExpression == null)
                throw new ArgumentNullException(nameof(ruleExpression));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Parser = parser;
            Context = context;
            RuleExpression = ruleExpression;
            Configuration = configuration;
        }

        public RuleResult Evaluate()
        {
            ModelEvaluator modelEvaluator = ModelEvaluator.GetInstance(Configuration.AssemblyFolder);
            ExpressionEvaluationContext expresssionEvaluationContext = new ExpressionEvaluationContext(modelEvaluator);

            logger.Debug("Starting evalution fo business rule expression:");
            logger.Debug(RuleExpression);
            ParserResult parserResult = Parser.Parse(expresssionEvaluationContext, RuleExpression);
            logger.Debug("Ending evaluation");

            return RuleResult.ParseFrom(parserResult);
        }
    }
}