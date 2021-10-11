using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitCardGeneratorDotNetApi.Entities;

namespace UnitCardGeneratorDotNetApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(CardGeneratorContext context)
        {
            if (context.Rules.Any())
            {
                return;
            }

            var rules = new Rule[]
            {
                new Rule { RuleId = 1, Name = "Stabilizers", Description= "+1 to Hit for Moving Rof" }
            };
            context.Rules.AddRange(rules);
            context.SaveChanges();
        }
    }
}
