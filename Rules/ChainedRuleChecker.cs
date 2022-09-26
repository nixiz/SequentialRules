using RuleSet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet.Rules
{
    public class ChainedRuleChecker : RuleBuilder<ChainedRuleChecker>, IRule
    {
        public ChainedRuleChecker()
        {

        }

        public Platform Platform { get; set; }
        public bool Run(RequestModel model)
        {
            IRule ruleChain = NextRule;
            while (ruleChain != null)
            {
                if (ruleChain.Run(model))
                {
                    ruleChain = ruleChain.NextRule;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
