using RuleSet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleSet.Rules
{
    public class CheckTokenExpireRule : RuleBuilder<ChainedRuleChecker>, IRule
    {
        public CheckTokenExpireRule()
        {
        }
        public Platform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case Platform.Gsm:
                    {
                        NextRule.Platform = Platform.Gsm;
                        if (model.TokenExpireDate < FakeData.TokenExpireDate.AddHours(2))
                        {
                            return true;
                        }
                        return false;
                    }
                case Platform.Web:
                    {
                        NextRule.Platform = Platform.Web;
                        if (model.TokenExpireDate < FakeData.TokenExpireDate)
                        {
                            return true;
                        }
                        return false;
                    }
                default:
                    {
                        return false;

                    }
            }
        }
    }
}
