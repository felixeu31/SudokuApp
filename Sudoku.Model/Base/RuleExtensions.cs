using System.Collections.Generic;

namespace SudokuApp.Model.Base
{
    public static class RuleExtensions
    {       
        public static void CheckRule(this IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
