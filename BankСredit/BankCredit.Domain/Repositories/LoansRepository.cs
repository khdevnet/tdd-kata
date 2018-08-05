using BankCredit.Domain.Entities;
using BankCredit.Domain.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankCredit.Domain.Repositories
{
    public class LoansRepository : ILoansRepository
    {
        private readonly List<PersonalLoan> loans;

        public LoansRepository()
        {
            loans = new List<PersonalLoan>();
        }

        public PersonalLoan Add(PersonalLoan loan)
        {
            loans.Add(loan);
            return loan;
        }

        public PersonalLoan Get(Guid id)
        {
            return loans.FirstOrDefault(l => l.Id == id);
        }
    }
}