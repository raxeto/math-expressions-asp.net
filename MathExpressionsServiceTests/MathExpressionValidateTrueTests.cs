using MathExpressions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionsServiceTests
{
    public class MathExpressionValidateTrueTests
    {
        [Fact]
        public void Validate_NoOperation_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_NoOperation_PlusSign_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is +5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_NoOperation_MinusSign_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is -5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_NoOperation_CI_Returns_True()
        {
            var expression = new MathExpression() { Expression = "WhAt iS 5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_NoOperation_Spaces_Returns_True()
        {
            var expression = new MathExpression() { Expression = " What   is   5 ? " };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Add_Two_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 11 plus 5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Substract_Two_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 11 minus 50?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Multiply_Two_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 2 multiplied by 50?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Divide_Two_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 62 divided by 2?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_NoOperation_Negative_Number_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is -5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Add_Two_Negative_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is -11 plus -5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Substract_Two_Negative_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is -11 minus -50?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Multiply_Two_Negative_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is -2 multiplied by -50?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Multiply_Positive_And_Negative_Number_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 2 multiplied by -50?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Divide_Two_Negative_Numbers_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is -62 divided by -2?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Divide_Positive_And_Negative_Number_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 62 divided by -2?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Add_And_Substract_Operations_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 5 plus 3 minus 1?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Add_And_Multiply_Operations_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 3 plus 2 multiplied by 3?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Add_And_Divide_Operations_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 3 plus 7 divided by 5?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Three_Operations_With_Add_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 3 plus 7 divided by 5 minus 1?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Three_Operations_With_Substract_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 30 minus 7 plus 10 divided by 11?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Three_Operations_With_Multiply_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 2 multiplied by 7 plus 6 divided by 10?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }

        [Fact]
        public void Validate_Three_Operations_With_Divide_Returns_True()
        {
            var expression = new MathExpression() { Expression = "What is 21 divided by -7 plus 6 plus 2?" };

            var result = expression.Validate();

            Assert.True(result.isValid);
        }
    }
}
