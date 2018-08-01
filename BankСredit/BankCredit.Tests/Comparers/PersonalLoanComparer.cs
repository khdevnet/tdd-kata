using System;
using System.Collections.Generic;
using System.Linq;
using BankCredit.WebApi.Models;

namespace BankCredit.Tests.Comparers
{
    internal class PersonalLoanComparer : BaseModelComparer<PersonalLoan>, IEqualityComparer<PersonalLoan>
    {
        public bool Equals(PersonalLoan x, PersonalLoan y)
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