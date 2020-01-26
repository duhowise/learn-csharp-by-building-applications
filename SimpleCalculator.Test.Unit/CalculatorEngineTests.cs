using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTests
    {

        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();
        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidAnswerForNonSymbolOperations()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("ADD", number1, number2);

            Assert.AreEqual(3,result);
        }
        
        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidAnswerForSymbolOperations()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("+", number1, number2);

            Assert.AreEqual(3,result);
        }
    }
}
