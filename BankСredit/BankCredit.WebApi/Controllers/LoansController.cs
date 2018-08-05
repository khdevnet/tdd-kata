using System;
using System.Net;
using AutoMapper;
using BankCredit.Domain.Entities;
using BankCredit.Domain.Enum;
using BankCredit.Domain.Extensibility;
using BankCredit.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankCredit.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : ApiControllerBase
    {
        private readonly ILoanCalculator loanCalculator;
        private readonly IMapper mapper;
        private readonly ILoansRepository loansRepository;

        public LoansController(ILoanCalculator loanCalculator, IMapper mapper, ILoansRepository loansRepository)
        {
            this.loanCalculator = loanCalculator;
            this.mapper = mapper;
            this.loansRepository = loansRepository;
        }

        [HttpGet]
        public PersonalLoanModel GetTemplate(LoanType loanType)
        {
            return new PersonalLoanModel { Amount = 10000, TermMonths = 12, RatePercents = 6, Payback = Payback.EveryMonth };
        }

        [HttpPost]
        public IActionResult Create([FromBody]PersonalLoanModel loan)
        {
            if (IsModelValid(out var errors))
            {
                return new CreatedResult(nameof(LoansController.Get), new ResponseModel<PersonalLoanModel> { Data = loan });
            }
            else
            {
                return new ObjectResult(new ResponseModel { Errors = errors }) { StatusCode = (int?)HttpStatusCode.BadRequest };
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var loan = loansRepository.Get(id);
            if (loan == null)
            {
                return new NotFoundResult();
            }

            return Ok(new ResponseModel<PersonalLoanModel> { Data = mapper.Map<PersonalLoanModel>(loan) });
        }

        public IActionResult Calculate(PersonalLoanModel data)
        {
            if (IsModelValid(out var errors))
            {
                return Ok(new ResponseModel<LoanCalculationsModel>
                {
                    Data = mapper.Map<LoanCalculationsModel>(
                        loanCalculator.Calculate(mapper.Map<PersonalLoan>(data)))
                });
            }
            else
            {
                return new ObjectResult(new ResponseModel { Errors = errors }) { StatusCode = (int?)HttpStatusCode.BadRequest };
            }
        }
    }
}