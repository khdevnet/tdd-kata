using BankCredit.Domain.Entities;
using BankCredit.Domain.Extensibility;

namespace BankCredit.Domain
{
    public class LoanCalculator : ILoanCalculator
    {
        public LoanCalculations Calculate(PersonalLoan loan)
        {
            return new LoanCalculations(
                 getOneMonthAmount(loan),
                 getTotalAmount(loan),
                 getOneMonthAmount(loan) * loan.TermMonths - loan.Amount
                );
        }

        private decimal getOnePercentsAmount(decimal amount) => amount / 100;

        private decimal getOneMonthAmount(PersonalLoan loan) => getOnePercentsAmount(getOneMonthAmountWithoutPercents(loan)) * loan.RatePercents + getOneMonthAmountWithoutPercents(loan);

        private decimal getTotalAmount(PersonalLoan loan) => getOneMonthAmount(loan) * loan.TermMonths;

        private decimal getOneMonthAmountWithoutPercents(PersonalLoan loan) => loan.Amount / loan.TermMonths;
    }
}