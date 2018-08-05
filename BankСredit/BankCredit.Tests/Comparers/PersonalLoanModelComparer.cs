using System.Collections.Generic;
using BankCredit.WebApi.Models;

namespace BankCredit.Tests.Comparers
{
    internal class PersonalLoanModelComparer : BaseModelComparer<PersonalLoanModel>, IEqualityComparer<PersonalLoanModel>
    {
        public bool Equals(PersonalLoanModel x, PersonalLoanModel y)
        {

            if (x == null || y == null)
            {
                return false;
            }

            return x.Amount == y.Amount &&
                   x.Payback == y.Payback &&
                   x.RatePercents == y.RatePercents &&
                   x.TermMonths == y.TermMonths;
        }
    }
}