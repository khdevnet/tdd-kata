using System.ComponentModel.DataAnnotations;
using BankCredit.WebApi.Enum;

namespace BankCredit.WebApi.Models
{
    public class PersonalLoan
    {
        public PersonalLoan(
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

        [Range(1000, 100000, ErrorMessage = "Amount should be less then 100000 and more then 1000.")]
        public decimal Amount { get; }

        public int TermMonths { get; }

        public int RatePercents { get; }

        public Payback Payback { get; }
    }
}