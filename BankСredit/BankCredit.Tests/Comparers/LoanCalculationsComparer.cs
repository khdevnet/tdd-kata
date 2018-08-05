using BankCredit.Domain.Entities;
using System.Collections.Generic;

namespace BankCredit.Tests.Comparers
{
    internal class LoanCalculationsComparer : BaseModelComparer<LoanCalculations>, IEqualityComparer<LoanCalculations>
    {
        public bool Equals(LoanCalculations x, LoanCalculations y)
        {
            return x.OneTimePayment == y.OneTimePayment &&
                 x.Total == y.Total &&
                 x.TotalInterest == y.TotalInterest;
        }
    }
}