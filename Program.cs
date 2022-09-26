using RuleSet.Models;
using RuleSet.Rules;
using System;

namespace RuleSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RequestModel model = new();
            model.IMEI = "111222333444555";
            model.RefreshToken = "98349785389732";
            //model.Token = "234234223423";
            model.UserID = 1;
            model.TokenExpireDate = DateTime.Now.AddHours(3);

            ChainedRuleChecker checker = new ChainedRuleChecker();
            checker
                .Append(new CheckPlatformRule())
                .Append(new CheckTokenRule())
                .Append(new CheckTokenExpireRule())
                .Append(new CheckRefreshToken());

            var result = checker.Run(model);
            if (result)
            {
                Console.WriteLine("Authorized 200 OK!");
            }
            else
            {
                Console.WriteLine("Unauthorized 401!");
            }

            Console.WriteLine($"Token: {FakeData.Token}");
            Console.WriteLine($"RefreshToken: {FakeData.RefreshToken}");
            Console.WriteLine($"Token Expire Date: ${FakeData.TokenExpireDate}");
        }
    }
}
