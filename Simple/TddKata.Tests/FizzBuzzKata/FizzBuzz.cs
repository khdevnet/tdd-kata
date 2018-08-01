using System;
using System.Globalization;
using System.Linq;

namespace TddKata.Tests.FizzBuzzKata
{
    public class FizzBuzz
    {
        public string PrintFizzBuzz()
        {
            var resultFizzBuzz = string.Empty;
            resultFizzBuzz = GetNumbers(resultFizzBuzz);
            return resultFizzBuzz;
        }

        public string PrintFizzBuzz(int number)
        {
            CanThrowArgumentExceptionWhenNumberNotInRule(number);

            var result = GetFizzBuzzResult(number+1);

            if (string.IsNullOrEmpty(result))
                result = GetFizzResult(number);
            if (string.IsNullOrEmpty(result))
                result = GetBuzzResult(number);

            return string.IsNullOrEmpty(result) ? number.ToString(CultureInfo.InvariantCulture) : result;
        }


        private string GetFizzBuzzResult(int number)
        {
            string result = null;
            if (IsFizz(number) && IsBuzz(number)) result = "FizzBuzz";
            return result;
        }

        private string GetBuzzResult(int number)
        {
            string result = null;
            if (IsBuzz(number)) result = "Buzz";
            return result;
        }

        private string GetFizzResult(int number)
        {
            string result = null;
            if (IsFizz(number)) result = "Fizz";
            return result;
        }

        private void CanThrowArgumentExceptionWhenNumberNotInRule(int number)
        {
            if (number > 100 || number < 1)
                throw new ArgumentException(
                    string.Format(
                        "entered number is [{0}], which does not meet rule, entered number should be between 1 to 100.",
                        number));
        }

        private string GetNumbers(string resultFizzBuzz)
        {
            for (var i = 1; i <= 100; i++)
            {
                var printNumber = string.Empty;
                if (IsFizz(i)) printNumber += "Fizz";
                if (IsBuzz(i)) printNumber += "Buzz";
                if (IsNumber(printNumber))
                    printNumber = i.ToString(CultureInfo.InvariantCulture);
                resultFizzBuzz += " " + printNumber;
            }
            return resultFizzBuzz.Trim();
        }

        private bool IsNumber(string printNumber) => string.IsNullOrEmpty(printNumber);

        private bool IsBuzz(int i) => i % 5 == 0;

        private bool IsFizz(int i) => i % 3 == 0;
    }
}
