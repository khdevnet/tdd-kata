using System;
using System.Linq;

namespace TddKata.Tests.CalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers) => string.IsNullOrEmpty(numbers)
            ? 0
            : GetSum(numbers);

        private static int GetSum(string numbers)
        {
            string delimiter = GetPossibleDelimiter();
            string newnumbers = numbers;

            if (HasSpecificDelimiter(numbers))
            {

                delimiter = GetSpecificDelimiter(numbers);
                newnumbers = GetSpecificNumbers(numbers);
            }

            return ContainsAny(numbers, delimiter)
                ? newnumbers.Split(delimiter.ToCharArray()).Sum(ParseToInt)
                : ParseToInt(newnumbers);
        }

        private static bool HasSpecificDelimiter(string numbers) => numbers.StartsWith("//");

        private static string GetPossibleDelimiter() => ",\n";

        private static string GetSpecificDelimiter(string numbers) => numbers.Substring(2, numbers.IndexOf("\n", StringComparison.Ordinal) - 2);

        private static string GetSpecificNumbers(string numbers) => numbers.Substring(numbers.IndexOf("\n", StringComparison.Ordinal) + 1,
            numbers.Length - numbers.IndexOf("\n", StringComparison.Ordinal) - 1);

        private static int ParseToInt(string n)
        {
            int result = IsGreaterThanThousand(Convert.ToInt32(n))
                ? 0
                : Convert.ToInt32(string.IsNullOrEmpty(n) ? "0" : n);
            ValidateNumbersAsPerRule(result);

            return result;
        }

        private static bool IsGreaterThanThousand(int nn) => nn > 1000;


        private static bool ContainsAny(string input, string getPossibleDelimiters) => getPossibleDelimiters.ToCharArray().Any(input.Contains);

        private static void ValidateNumbersAsPerRule(int number)
        {
            if (number < 0)
                throw new ArgumentException(
                    $"string contains [{number}], which does not meet rule. entered number should not negative.");
        }
    }
}