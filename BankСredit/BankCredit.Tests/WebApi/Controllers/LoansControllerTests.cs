using System;
using Xunit;
namespace BankCredit.Tests.WebApi.Controllers
{
    public class LoansControllerTests
    {
        [Fact]
        public void GetTemplate()
        {
            var loanController = new LoansController();

            var template = loanController.GetTemplate("personal");

            var expected = new PersonalLoanTemplate(10000, 12, 6, Payback.EveryMonth);

            Assert.Equal(expected, template);

        }
    }

        internal class PersonalLoanTemplate
    {
        public PersonalLoanTemplate(
            decimal amount,
            int termMonths,
            int ratePercents,
            Payback payback)
        {
            Amount = amount;
            TermMonths = termMonths;
            RatePercents = ratePercents;
            Payback = payback;
        }

        public decimal Amount { get; }
        public int TermMonths { get; }
        public int RatePercents { get; }
        public Payback Payback { get; }
    }

    internal class LoansController
    {
        public LoansController()
        {
        }

        internal PersonalLoanTemplate GetTemplate(string v)
        {
            throw new NotImplementedException();
        }
    }


}