namespace BankCredit.Domain.Entities
{
    public class LoanCalculations
    {
        public LoanCalculations(decimal oneTimePayment, decimal total, decimal totalInterest)
        {
            OneTimePayment = oneTimePayment;
            Total = total;
            TotalInterest = totalInterest;
        }

        public decimal OneTimePayment { get; }

        public decimal Total { get; }

        public decimal TotalInterest { get; }
    }
}