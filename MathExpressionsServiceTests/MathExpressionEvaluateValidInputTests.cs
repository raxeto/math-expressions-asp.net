using Microsoft.AspNetCore.Mvc;
using MathExpressions;
using MathExpressions.Models;

namespace MathExpressionsServiceTests
{
    public class MathExpressionEvaluateValidInputTests
    {
        [Fact]
        public void Evaluate_NoOperation_Returns_Number()
        {
            var expression = new MathExpression() { Expression = "What is 5?" };

            var result = expression.Evaluate();

            Assert.Equal(5.0m, result);
        }

        [Fact]
        public void Evaluate_NoOperation_PlusSign_Returns_Number()
        {
            var expression = new MathExpression() { Expression = "What is +5?" };

            var result = expression.Evaluate();

            Assert.Equal(5.0m, result);
        }

        [Fact]
        public void Evaluate_NoOperation_MinusSign_Returns_Number()
        {
            var expression = new MathExpression() { Expression = "What is -5?" };

            var result = expression.Evaluate();

            Assert.Equal(-5.0m, result);
        }

        [Fact]
        public void Evaluate_NoOperation_CI_Returns_Number()
        {
            var expression = new MathExpression() { Expression = "WhAt iS 5?" };

            var result = expression.Evaluate();

            Assert.Equal(5.0m, result);
        }

        [Fact]
        public void Evaluate_NoOperation_Spaces_Returns_Number()
        {
            var expression = new MathExpression() { Expression = " What   is   5 ? " };

            var result = expression.Evaluate();

            Assert.Equal(5.0m, result);
        }

        [Fact]
        public void Evaluate_Add_Two_Numbers_Returns_Sum()
        {
            var expression = new MathExpression() { Expression = "What is 11 plus 5?" };

            var result = expression.Evaluate();

            Assert.Equal(16.0m, result);
        }

        [Fact]
        public void Evaluate_Substract_Two_Numbers_Returns_Difference()
        {
            var expression = new MathExpression() { Expression = "What is 11 minus 50?" };

            var result = expression.Evaluate();

            Assert.Equal(-39.0m, result);
        }

        [Fact]
        public void Evaluate_Multiply_Two_Numbers_Returns_Product()
        {
            var expression = new MathExpression() { Expression = "What is 2 multiplied by 50?" };

            var result = expression.Evaluate();

            Assert.Equal(100, result);
        }

        [Fact]
        public void Evaluate_Divide_Two_Numbers_Returns_Quotient_Intiger()
        {
            var expression = new MathExpression() { Expression = "What is 62 divided by 2?" };

            var result = expression.Evaluate();

            Assert.Equal(31, result);
        }

        [Fact]
        public void Evaluate_Divide_Two_Numbers_Returns_Quotient_Decimal()
        {
            var expression = new MathExpression() { Expression = "What is 61 divided by 2?" };

            var result = expression.Evaluate();

            Assert.Equal(30.5m, result);
        }

        [Fact]
        public void Evaluate_Divide_Two_Numbers_Throws_DivideByZeroException()
        {
            var expression = new MathExpression() { Expression = "What is 61 divided by 0?" };

            Assert.Throws<DivideByZeroException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_NoOperation_Negative_Number_Returns_Number()
        {
            var expression = new MathExpression() { Expression = "What is -5?" };

            var result = expression.Evaluate();

            Assert.Equal(-5.0m, result);
        }

        [Fact]
        public void Evaluate_Add_Two_Negative_Numbers_Returns_Sum()
        {
            var expression = new MathExpression() { Expression = "What is -11 plus -5?" };

            var result = expression.Evaluate();

            Assert.Equal(-16.0m, result);
        }

        [Fact]
        public void Evaluate_Substract_Two_Negative_Numbers_Returns_Difference()
        {
            var expression = new MathExpression() { Expression = "What is -11 minus -50?" };

            var result = expression.Evaluate();

            Assert.Equal(39.0m, result);
        }

        [Fact]
        public void Evaluate_Multiply_Two_Negative_Numbers_Returns_Product()
        {
            var expression = new MathExpression() { Expression = "What is -2 multiplied by -50?" };

            var result = expression.Evaluate();

            Assert.Equal(100, result);
        }

        [Fact]
        public void Evaluate_Multiply_Positive_And_Negative_Number_Returns_Product()
        {
            var expression = new MathExpression() { Expression = "What is 2 multiplied by -50?" };

            var result = expression.Evaluate();

            Assert.Equal(-100, result);
        }

        [Fact]
        public void Evaluate_Divide_Two_Negative_Numbers_Returns_Quotient_Intiger()
        {
            var expression = new MathExpression() { Expression = "What is -62 divided by -2?" };

            var result = expression.Evaluate();

            Assert.Equal(31, result);
        }

        [Fact]
        public void Evaluate_Divide_Positive_And_Negative_Number_Returns_Quotient_Intiger()
        {
            var expression = new MathExpression() { Expression = "What is 62 divided by -2?" };

            var result = expression.Evaluate();

            Assert.Equal(-31, result);
        }

        [Fact]
        public void Evaluate_Add_And_Substract_Operations_Returns_Result()
        {
            var expression = new MathExpression() { Expression = "What is 5 plus 3 minus 1?" };

            var result = expression.Evaluate();

            Assert.Equal(7, result);
        }

        [Fact]
        public void Evaluate_Add_And_Multiply_Operations_Returns_Result()
        {
            var expression = new MathExpression() { Expression = "What is 3 plus 2 multiplied by 3?" };

            var result = expression.Evaluate();

            Assert.Equal(15, result);
        }

        [Fact]
        public void Evaluate_Add_And_Divide_Operations_Returns_Result()
        {
            var expression = new MathExpression() { Expression = "What is 3 plus 7 divided by 5?" };

            var result = expression.Evaluate();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Evaluate_Three_Operations_With_Add_Returns_Result()
        {
            var expression = new MathExpression() { Expression = "What is 3 plus 7 divided by 5 minus 1?" };

            var result = expression.Evaluate();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Evaluate_Three_Operations_With_Substract_Returns_Result()
        {
            var expression = new MathExpression() { Expression = "What is 30 minus 7 plus 10 divided by 11?" };

            var result = expression.Evaluate();

            Assert.Equal(3, result);
        }

        [Fact]
        public void Evaluate_Three_Operations_With_Multiply_Returns_Result()
        {
            var expression = new MathExpression() { Expression = "What is 2 multiplied by 7 plus 6 divided by 10?" };

            var result = expression.Evaluate();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Evaluate_Three_Operations_With_Divide_Returns_Result()
        {
            var expression = new MathExpression() { Expression = "What is 21 divided by -7 plus 6 plus 2?" };

            var result = expression.Evaluate();

            Assert.Equal(5, result);
        }
    }
}