using System.Net;
using System.Net.Http;
using BankCredit.Tests.Comparers;
using BankCredit.WebApi.Controllers;
using BankCredit.WebApi.Enum;
using BankCredit.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
namespace BankCredit.Tests.WebApi.Controllers
{
    public class LoansControllerTests
    {

        private LoansController loansController = new LoansController();

        [Fact]
        public void GetTemplateTest()
        {
            var loanController = new LoansController();

            var template = loanController.GetTemplate(LoanType.Personal);

            var expected = new PersonalLoan(10000, 12, 6, Payback.EveryMonth);

            Assert.Equal(expected, template, new PersonalLoanComparer());
        }

        [Fact]
        public void CreateTest()
        {
            var expectedResponse = new ResponseModel<PersonalLoan>()
            {
                Data = new PersonalLoan(10000, 12, 6, Payback.EveryMonth)
            };
            var expected = new CreatedResult(nameof(LoansController.Get), expectedResponse);
            var actual = loansController.Create(expectedResponse.Data);

            Assert.Equal(
                expected,
                (CreatedResult)actual,
                GetActionResultResponseDataModelComparer()
                );
        }

        [Fact]
        public void CreateAmountRangeIsNotValidTest()
        {
            var errorMerssage = $"{nameof(PersonalLoan.Amount)} should be less then 100000 and more then 1000.";
            loansController.ModelState.AddModelError(nameof(PersonalLoan.Amount), errorMerssage);

            var expectedData = new ResponseModel
            {
                Errors = new[]
                {
                    new MessageModel(){ Message = errorMerssage }
                }
            };

            var expected = new ObjectResult(expectedData)
            {
                StatusCode = (int?)HttpStatusCode.BadRequest,
            };
            var actual = loansController.Create(new PersonalLoan(100, 12, 6, Payback.EveryMonth));

            Assert.Equal(expected, (ObjectResult)actual, GetActionResultResponseModelComparer());
        }

        private static ActionResultComparer<ResponseModel<PersonalLoan>> GetActionResultResponseDataModelComparer()
        {
            return new ActionResultComparer<ResponseModel<PersonalLoan>>(
                new ResponseModelDataComparer<PersonalLoan>(
                    new PersonalLoanComparer(),
                    new MessageModelComparer()
                    ));
        }

        private static ActionResultComparer<ResponseModel> GetActionResultResponseModelComparer()
        {
            return new ActionResultComparer<ResponseModel>(new ResponseModelComparer(new MessageModelComparer()));
        }

    }
}