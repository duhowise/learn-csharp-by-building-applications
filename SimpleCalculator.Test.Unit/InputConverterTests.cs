using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
   [TestClass]
   public class InputConverterTests
   {

       private readonly InputConverter _inputConverter=new InputConverter();
        [TestMethod]
        public void ConvertValidIntStringToDouble()
        {
            string inputNumber = "5";

            double convertedNumber = _inputConverter.ConvertInputToNumeric(inputNumber);

            Assert.AreEqual(5.0,convertedNumber);
        } 
        
        
        [TestMethod]
      [ExpectedException(typeof(ArgumentException), "Expected a Numeric Value")]  public void ThrowsArgumentExceptionWhenInvalidStringEntered()
        {
            string inputNumber = "somemore";

            double convertedNumber = _inputConverter.ConvertInputToNumeric(inputNumber);

        }

    }
}