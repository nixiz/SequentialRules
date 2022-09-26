using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet.Rules
{
    public abstract class RuleBuilder<Rule> where Rule : IRule
    {
        public IRule NextRule { get; set; }

        public RuleBuilder<NewRule> Append<NewRule>(RuleBuilder<NewRule> newRule) where NewRule : IRule
        {
            NextRule = (IRule)newRule;
            return newRule;
        }
    }

}
