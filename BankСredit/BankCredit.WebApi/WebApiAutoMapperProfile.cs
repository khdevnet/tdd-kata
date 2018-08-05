using AutoMapper;
using BankCredit.Domain.Entities;
using BankCredit.WebApi.Models;

namespace BankCredit.WebApi
{
    public class WebApiAutoMapperProfile : Profile
    {
        public WebApiAutoMapperProfile()
        {
            CreateMap<PersonalLoan, PersonalLoanModel>();
            CreateMap<LoanCalculations, LoanCalculationsModel>();
        }
    }
}