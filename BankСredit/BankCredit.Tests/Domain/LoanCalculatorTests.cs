using BankCredit.Domain;
using BankCredit.Domain.Entities;
using BankCredit.Domain.Enum;
using BankCredit.Tests.Comparers;
using Xunit;

namespace BankCredit.Tests.Domain
{
    public class LoanCalculatorTests
    {
        [Fact]
        public void CalculateTest()
        {
            var calculator = new LoanCalculator();

            LoanCalculations actual = calculator.Calculate(new PersonalLoan(100000, 10, 6, Payback.EveryMonth));

            Assert.Equal(new LoanCalculations(10600m, 106000m, 6000m), actual, new LoanCalculationsComparer());
        }
    }
}