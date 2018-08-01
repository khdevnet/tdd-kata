using System;
using System.Net;
using BankCredit.WebApi.Enum;
using BankCredit.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankCredit.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : ApiControllerBase
    {
        public LoansController()
        {
        }

        [HttpGet]
        public PersonalLoan GetTemplate(LoanType loanType)
        {
            return new PersonalLoan(10000, 12, 6, Payback.EveryMonth);
        }

        [HttpPost]
        public IActionResult Create(PersonalLoan loan)
        {
            if (IsModelValid(out var errors))
            {
                return new CreatedResult(nameof(LoansController.Get), new ResponseModel<PersonalLoan> { Data = loan });
            }
            else
            {
                return new ObjectResult(new ResponseModel { Errors = errors }) { StatusCode = (int?)HttpStatusCode.BadRequest };
            }
        }

        [HttpGet]
        public PersonalLoan Get(string id)
        {
            throw new NotImplementedException();
        }

    }
}