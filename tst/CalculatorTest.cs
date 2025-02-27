using NUnit.Framework;
using ProCalculator;

namespace ProCalculatorTests
{
    public class CalculatorTests
    {
        [Test]
        public void SimpleAddition()
        {
            var calculator = new Calculator("1 + 2");
            Assert.That(calculator.Evaluate(), Is.EqualTo(3.0));
        }

        [Test]
        public void SimpleSubtraction()
        {
            var calculator = new Calculator("1 - 2");
            Assert.That(calculator.Evaluate(), Is.EqualTo(-1.0));
        }

        [Test]
        public void SimpleMultiplication()
        {
            var calculator = new Calculator("2 * 3");
            Assert.That(calculator.Evaluate(), Is.EqualTo(6.0));
        }

        [Test]
        public void SimpleDivision()
        {
            var calculator = new Calculator("6 / 3");
            Assert.That(calculator.Evaluate(), Is.EqualTo(2.0));
        }

        [Test]
        public void OperatorPrecedence()
        {
            var calculator = new Calculator("1 + 2 * 3");
            Assert.That(calculator.Evaluate(), Is.EqualTo(7.0));
        }

        [Test]
        public void Parentheses()
        {
            var calculator = new Calculator("(1 + 2) * 3");
            Assert.That(calculator.Evaluate(), Is.EqualTo(9.0));
        }

        [Test]
        public void NestedParentheses()
        {
            var calculator = new Calculator("1 + (2 * (3 + 4))");
            Assert.That(calculator.Evaluate(), Is.EqualTo(15.0));
        }

        [Test]
        public void Exponentiation()
        {
            var calculator = new Calculator("2 ^ 3");
            Assert.That(calculator.Evaluate(), Is.EqualTo(8.0));
        }

        [Test]
        public void ExponentiationAssociativity()
        {
            var calculator = new Calculator("2 ^ 3 ^ 2");
            Assert.That(calculator.Evaluate(), Is.EqualTo(512.0));
        }

        [Test]
        public void DecimalNumbers()
        {
            var calculator = new Calculator("1.5 + 1");
            Assert.That(calculator.Evaluate(), Is.EqualTo(2.5));
        }

        [Test]
        public void NegativeNumbers()
        {
            var calculator = new Calculator("-1 - 1");
            Assert.That(calculator.Evaluate(), Is.EqualTo(-2.0));
        }

        [Test]
        public void CombinedOperations()
        {
            var calculator = new Calculator("1 + 2.5 * 2");
            Assert.That(calculator.Evaluate(), Is.EqualTo(6.0));
        }

        [Test]
        public void WhitespaceVariations()
        {
            var calculator = new Calculator(" 1 + 2 ");
            Assert.That(calculator.Evaluate(), Is.EqualTo(3.0));

            var calculator2 = new Calculator("1+2");
            Assert.That(calculator2.Evaluate(), Is.EqualTo(3.0));
        }

        [Test]
        public void MismatchedParentheses_ThrowsException()
        {
            var calculator = new Calculator("(1 + 2");
            Assert.Throws<ArgumentException>(() => calculator.Evaluate());

            var calculator2 = new Calculator("1 + 2)");
            Assert.Throws<ArgumentException>(() => calculator2.Evaluate());
        }

        [Test]
        public void InvalidExpression_ThrowsException()
        {
            var calculator = new Calculator("1 + ");
            Assert.Throws<ArgumentException>(() => calculator.Evaluate());

            var calculator2 = new Calculator("* 2");
            Assert.Throws<ArgumentException>(() => calculator2.Evaluate());
        }

        [Test]
        public void DivisionByZero_ThrowsException()
        {
            var calculator = new Calculator("1 / 0");
            Assert.Throws<DivideByZeroException>(() => calculator.Evaluate());
        }
    }
}