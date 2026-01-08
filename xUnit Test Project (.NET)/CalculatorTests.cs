using Operations;
using System.Collections.Generic;
using Xunit;
using src;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        private readonly Calculator _calc;

        public CalculatorTests()
        {

        }

        [Theory]
        [InlineData("1+2", 3)]
        [InlineData("  4 + 5 ", 9)]
        [InlineData("0+0", 0)]
        [InlineData("100+200+1", 301)]
        [InlineData("-10+15", 5)]


        public void TestAddition_Parameterized(string expression, int expected)
        {
            var operations = new List<IOperation> { new Addition() };
            var calc = new Calculator(operations);
            var result = calc.Calculate(expression);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("10-4", 6)]
        [InlineData("  20 - 5 ", 15)]
        [InlineData("0-0", 0)]
        [InlineData("100-50-25", 25)]
        [InlineData("-10-5", -15)]
        public void TestSubtraction_Parameterized(string expression, int expected)
        {
            var operations = new List<IOperation> { new Subtraction() };
            var calc = new Calculator(operations);
            var result = calc.Calculate(expression);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("5*6 ", 30)]
        [InlineData("  7 * 8 ", 56)]
        [InlineData("0*100", 0)]
        [InlineData("2*3*4", 24)]
        [InlineData("-3*5", -15)]
       
        public void TestMultiplication_Parameterized(string expression, int expected)
        {
            var operations = new List<IOperation> { new Multiplication() };
            var calc = new Calculator(operations);
            var result = calc.Calculate(expression);
            Assert.Equal(expected, result);
        }
    

        [Theory]
        [InlineData("20/4", 5)]
        [InlineData("  18 / 3 ", 6)]
        [InlineData("100/5/2", 10)]
        [InlineData("-15/3", -5)]
        [InlineData("0/2",0 )]

        public void TestDivision_Parameterized(string expression, int expected)
        {
            var operations = new List<IOperation> { new Division() };
            var calc = new Calculator(operations);
            var result = calc.Calculate(expression);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("2+3*4", 14)]       
        [InlineData("10-6/2", 7)]      
        [InlineData("-2*3+4", -2)]    
        [InlineData("2+3*4-6/2", 11)]  
        [InlineData("-20/-4+2", 7)]    
        [InlineData("4-20/2+2*3", 0)]
        [InlineData("18/3+2*5-4", 12)]
        [InlineData("2+3*4-6/2+5*2-3", 18)]

        public void TestOrderOfOperations(string expression, double expected)
        {
            var operations = new List<IOperation>
        { new Addition(), new Subtraction(), new Multiplication(), new Division() };
            var calc = new Calculator(operations);

            var result = calc.Calculate(expression);
            Assert.Equal(expected, result);
        }
    }

    }
