namespace MathExpressionsService.Models.Operations
{
    public static class MathOperationFactory
    {
        public static string[] AllowedOperations
        {
            get
            {
                return new string[]
                {
                    "plus",
                    "minus",
                    "multiplied by",
                    "divided by"
                };
            }
        }
        public static IMathOperation? Create(string operExpression)
        {
            operExpression = operExpression.ToLower();

            switch (operExpression)
            {
                case "plus":
                    return new Addition();
                case "minus":
                    return new Subtraction();
                case "multiplied by":
                    return new Multiplication();
                case "divided by":
                    return new Division();
            }

            return null;
        }
    }
}
