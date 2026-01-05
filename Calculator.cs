using Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace src
{
    public class Calculator
    {
        private readonly List<IOperation> _operations;

        public Calculator(List<IOperation> operations)
        {
            _operations = operations;
        }

        private IOperation GetOperation(char symbol)
        {
            var op = _operations.FirstOrDefault(o => o.Symbol == symbol.ToString());
            if (op == null)
                throw new InvalidOperationException($"Operation '{symbol}' not supported");
            return op;
        }

        public double Calculate(string expression)
        {
            expression = expression.Replace(" ", "");

            var numbers = new List<double>();
            var operators = new List<char>();
            int i = 0;

      
            while (i < expression.Length)
            {
                bool isNegative = false;
                if (expression[i] == '-' && (i == 0 || "+-*/".Contains(expression[i - 1])))
                {
                    isNegative = true;
                    i++;
                }

                int start = i;
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    i++;

                if (start == i)
                    throw new ArgumentException("Invalid expression");

                double number = double.Parse(expression.Substring(start, i - start));
                if (isNegative) number *= -1;

                numbers.Add(number);

                if (i < expression.Length)
                {
                    operators.Add(expression[i]);
                    i++;
                }
            }

            // ---------- * and / ----------
            for (i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '*' || operators[i] == '/')
                {
                    var op = GetOperation(operators[i]);
                    double result = op.Compute(numbers[i], numbers[i + 1]);

                    numbers[i] = result;
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            // ---------- + and - ----------
            double finalResult = numbers[0];
            for (i = 0; i < operators.Count; i++)
            {
                var op = GetOperation(operators[i]);
                finalResult = op.Compute(finalResult, numbers[i + 1]);
            }

                
                return finalResult;
       
        }
    }
}

