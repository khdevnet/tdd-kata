namespace BankCredit.WebApi.Models
{
    public class LoanCalculationsModel
    {
        public decimal OneTimePayment { get; set; }

        public decimal Total { get; set; }

        public decimal TotalInterest { get; set; }
    }
}