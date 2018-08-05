using BankCredit.Domain.Entities;

namespace BankCredit.Domain.Extensibility
{
    public interface ILoanCalculator
    {
        LoanCalculations Calculate(PersonalLoan loan);
    }
}