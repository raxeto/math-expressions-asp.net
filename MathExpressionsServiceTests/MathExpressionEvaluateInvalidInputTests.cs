using MathExpressions.Models;
using MathExpressionsService.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionsServiceTests
{
    public class MathExpressionEvaluateInvalidInputTests
    {
        [Fact]
        public void Evaluate_Empty_Input_Throws_EmptyQuestionException()
        {
            var expression = new MathExpression() { Expression = "" };

            Assert.Throws<EmptyQuestionException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_Whitespaces_Input_Throws_EmptyQuestionException()
        {
            var expression = new MathExpression() { Expression = "  " };

            Assert.Throws<EmptyQuestionException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_No_Operands_And_Operations_Throws_EmptyQuestionException()
        {
            var expression = new MathExpression() { Expression = "What is?" };

            Assert.Throws<EmptyQuestionException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_InvalidSyntax_Missed_First_Operand_Throws_InvalidSyntaxException()
        {
            var expression = new MathExpression() { Expression = "What is 45 plus?" };

            Assert.Throws<InvalidSyntaxException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_InvalidSyntax_Missed_Second_Operand_Throws_InvalidSyntaxException()
        {
            var expression = new MathExpression() { Expression = "What is plus 5?" };

            Assert.Throws<InvalidSyntaxException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_InvalidSyntax_Only_Operation_Throws_InvalidSyntaxException()
        {
            var expression = new MathExpression() { Expression = "What is plus?" };

            Assert.Throws<InvalidSyntaxException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_InvalidSyntax_Two_Operations_Throws_InvalidSyntaxException()
        {
            var expression = new MathExpression() { Expression = "What is 5 plus minus 3?" };

            Assert.Throws<InvalidSyntaxException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_InvalidSyntax_Three_Operations_Throws_InvalidSyntaxException()
        {
            var expression = new MathExpression() { Expression = "What is  plus -3 minus 4 multiplied by 100 ?" };

            Assert.Throws<InvalidSyntaxException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_UnsupportedOperation_Cubed_Throws_UnsupportedOperationException()
        {
            var expression = new MathExpression() { Expression = "What is 3 cubed?" };

            Assert.Throws<UnsupportedOperationException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_UnsupportedOperation_Sine_Throws_UnsupportedOperationException()
        {
            var expression = new MathExpression() { Expression = "What is sine value of 3?" };

            Assert.Throws<UnsupportedOperationException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_UnsupportedOperation_Logarithm_Throws_UnsupportedOperationException()
        {
            var expression = new MathExpression() { Expression = "What is logarithm of 16 with a base 4?" };

            Assert.Throws<UnsupportedOperationException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_NonMathQuestion_What_Is_Throws_NonMathQuestionException()
        {
            var expression = new MathExpression() { Expression = "What is cat?" };

            Assert.Throws<NonMathQuestionException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_NonMathQuestion_Who_Is_Throws_NonMathQuestionException()
        {
            var expression = new MathExpression() { Expression = "Who is the President of the United States?" };

            Assert.Throws<NonMathQuestionException>(() => expression.Evaluate());
        }

        [Fact]
        public void Evaluate_NonMathQuestion_Is_This_Throws_NonMathQuestionException()
        {
            var expression = new MathExpression() { Expression = "Is this a dog?" };

            Assert.Throws<NonMathQuestionException>(() => expression.Evaluate());
        }
    }
}
