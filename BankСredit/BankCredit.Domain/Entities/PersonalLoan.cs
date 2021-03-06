﻿using BankCredit.Domain.Enum;
using System;

namespace BankCredit.Domain.Entities
{
    public class PersonalLoan
    {
        public PersonalLoan(
            string name,
            decimal amount,
            int termMonths,
            int ratePercents,
            Payback payback,
            Guid id = default(Guid))
        {
            Name = name;
            Amount = amount;
            TermMonths = termMonths;
            RatePercents = ratePercents;
            Payback = payback;
            Id = id == null ? Guid.NewGuid() : id;
        }

        public Guid Id { get; }

        public string Name { get; }

        public decimal Amount { get; }

        public int TermMonths { get; }

        public int RatePercents { get; }

        public Payback Payback { get; }
    }
}