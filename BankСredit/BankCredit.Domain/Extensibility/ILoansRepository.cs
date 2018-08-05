using BankCredit.Domain.Entities;
using System;

namespace BankCredit.Domain.Extensibility
{
    public interface ILoansRepository
    {
        PersonalLoan Add(PersonalLoan loan);

        PersonalLoan Get(Guid id);
    }
}