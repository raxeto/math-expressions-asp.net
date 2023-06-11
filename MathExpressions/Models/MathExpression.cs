using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MathExpressionsService.Models;
using MathExpressionsService.Models.Exceptions;
using MathExpressionsService.Models.Operations;

namespace MathExpressions.Models
{
    public class MathExpression
    {
        private string _expression = string.Empty;
        public string Expression 
        {
            get
            {
                return _expression;
            }
            set
            {
                // Removes all leading and trailing whitespaces and replace many whitespaces with single. Keeps regular expressions simpler, unify errors
                _expression = Regex.Replace(value, @"\s+", " ").Trim();
            }
        } 

        public decimal Evaluate()
        {
            var validateRes = Validate();

            if (!validateRes.isValid)
            {
                throw validateRes.exception ?? new MathExpressionException();
            }

            string[] parts = Regex.Split(Expression.TrimEnd('?').ToLower(), @"\s+");

            decimal result = decimal.Parse(parts[2]);

            for (int i = 3; i < parts.Length - 1; i += 2)
            {
                string operation = parts[i];

                decimal operand;

                while (!Decimal.TryParse(parts[i + 1], out operand))
                {
                    operation += (" " + parts[i + 1]);
                    ++i;
                }

                IMathOperation? mathOperation = MathOperationFactory.Create(operation);

                if (mathOperation != null)
                {
                    result = mathOperation.Eval(result, operand);
                }
            }

            return result;
        }

        public (bool isValid, MathExpressionException? exception) Validate()
        {
            string operations = @"\s+" + string.Join(@"\s+|\s+", MathOperationFactory.AllowedOperations.Select(o => o.Replace(" ", @"\s+"))) + @"\s+";

            string validPattern = string.Format(@"^What is ([-+]?\d+)(({0})([-+]?\d+))*\s*\?$", operations);

            if (Regex.IsMatch(Expression, validPattern, RegexOptions.IgnoreCase))
            {
                return (true, null);
            }

            string emptyQuestionPattern = @"^What is\s*\?*$";
            
            if (string.IsNullOrWhiteSpace(Expression) || Regex.IsMatch(Expression, emptyQuestionPattern, RegexOptions.IgnoreCase))
            {
                return (false, new EmptyQuestionException());
            }

            // Invalid syntax - What is [(number)0-n (plus|minus|multiplied by|divided by)0-n (number)0-n]1-n?
            operations = string.Join(@"|", MathOperationFactory.AllowedOperations.Select(o => o.Replace(" ", @"\s+")));
            string invalidSyntaxPattern = string.Format(@"^What is\s+(([-+]?\d+)*\s*({0})*\s*([-+]?\d+)*)+\s*\?$", operations);

            if (Regex.IsMatch(Expression, invalidSyntaxPattern, RegexOptions.IgnoreCase))
            {
                return (false, new InvalidSyntaxException());
            }

            // Unsupported operation - What is [(word)0-n number (word)0-n]1-n?
            // (\b\w+\b\s*)* - matches 0 or more words
            string unsupportedOperPattern = @"^What is ((\b\w+\b\s*)*[-+]?\d+\s*(\b\w+\b\s*)*)+\?$";

            if (Regex.IsMatch(Expression, unsupportedOperPattern, RegexOptions.IgnoreCase))
            {
                return (false, new UnsupportedOperationException());
            }

            return (false, new NonMathQuestionException());

        }
    }
}
