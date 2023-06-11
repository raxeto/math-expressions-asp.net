using MathExpressions.Models;
using MathExpressionsService.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionsServiceTests
{
    public class MathExpressionValidateFalseTests
    {
        [Fact]
        public void Validate_Empty_Input_Returns_False()
        {
            var expression = new MathExpression() { Expression = "" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<EmptyQuestionException>(result.exception);
        }

        [Fact]
        public void Validate_Whitespaces_Input_Returns_False()
        {
            var expression = new MathExpression() { Expression = "  " };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<EmptyQuestionException>(result.exception);
        }

        [Fact]
        public void Validate_No_Operands_And_Operations_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<EmptyQuestionException>(result.exception);
        }

        [Fact]
        public void Validate_InvalidSyntax_Missed_First_Operand_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is 45 plus?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<InvalidSyntaxException>(result.exception);
        }

        [Fact]
        public void Validate_InvalidSyntax_Missed_Second_Operand_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is plus 5?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<InvalidSyntaxException>(result.exception);
        }

        [Fact]
        public void Validate_InvalidSyntax_Only_Operation_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is plus?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<InvalidSyntaxException>(result.exception);
        }

        [Fact]
        public void Validate_InvalidSyntax_Two_Operations_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is 5 plus minus 3?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<InvalidSyntaxException>(result.exception);
        }

        [Fact]
        public void Validate_InvalidSyntax_Three_Operations_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is  plus -3 minus 4 multiplied by 100 ?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<InvalidSyntaxException>(result.exception);
        }

        [Fact]
        public void Validate_UnsupportedOperation_Cubed_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is 3 cubed?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<UnsupportedOperationException>(result.exception);
        }

        [Fact]
        public void Validate_UnsupportedOperation_Sine_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is sine value of 3?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<UnsupportedOperationException>(result.exception);
        }

        [Fact]
        public void Validate_UnsupportedOperation_Logarithm_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is logarithm of 16 with a base 4?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<UnsupportedOperationException>(result.exception);
        }

        [Fact]
        public void Validate_NonMathQuestion_What_Is_Returns_False()
        {
            var expression = new MathExpression() { Expression = "What is cat?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<NonMathQuestionException>(result.exception);
        }

        [Fact]
        public void Validate_NonMathQuestion_Who_Is_Returns_False()
        {
            var expression = new MathExpression() { Expression = "Who is the President of the United States?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<NonMathQuestionException>(result.exception);
        }

        [Fact]
        public void Validate_NonMathQuestion_Is_This_Returns_False()
        {
            var expression = new MathExpression() { Expression = "Is this a dog?" };

            var result = expression.Validate();

            Assert.False(result.isValid);

            Assert.IsAssignableFrom<NonMathQuestionException>(result.exception);
        }
    }
        
}
