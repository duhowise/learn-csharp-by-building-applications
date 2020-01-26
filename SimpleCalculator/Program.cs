using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputConverter inputConverter=new InputConverter();
                CalculatorEngine calculatorEngine=new CalculatorEngine();
                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation,firstNumber,secondNumber);

                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }
        
    }

    public class CalculatorEngine
    {
        public double Calculate(string operation, in double firstNumber, in double secondNumber)
        {
            double result;
            switch (operation.ToLower())
            {
                case "add":
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "subtract":
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "multiply":
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                
                case "divide":
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    throw new InvalidOperationException("specified operation not recognized");

            }

            return result;
        }
    }

    public class InputConverter
    {
        public double ConvertInputToNumeric(string input)
        {
            if (!double.TryParse(input,out var convertedNumber))throw new ArgumentException("Expected a Numeric Value");

            return convertedNumber;
        }
    }
}
