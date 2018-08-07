using BankCredit.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankCredit.WebApi.Models
{
    public class PersonalLoanModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1000, 100000, ErrorMessage = "Amount should be less then 100000 and more then 1000.")]
        public decimal? Amount { get; set; }

        [Required]
        [Range(1, 36, ErrorMessage = "TermMonths should be between 1 and 36.")]
        public int? TermMonths { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "RatePercents should be between 1 and 12.")]
        public int? RatePercents { get; set; }

        [Required]
        public Payback? Payback { get; set; }
    }
}