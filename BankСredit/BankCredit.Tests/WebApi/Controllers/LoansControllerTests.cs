using System;
using System.Net;
using AutoMapper;
using BankCredit.Domain.Entities;
using BankCredit.Domain.Enum;
using BankCredit.Domain.Extensibility;
using BankCredit.Tests.Comparers;
using BankCredit.WebApi.Controllers;
using BankCredit.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace BankCredit.Tests.WebApi.Controllers
{
    public class LoansControllerTests : UnitTestsBase
    {
        private LoansController loansController;
        private Mock<IMapper> mapperMock;
        private Mock<ILoanCalculator> calculatorMock;
        private Mock<ILoansRepository> loansRepositoryMock;
        private readonly Guid PersonalLoanId = Guid.Parse("97022aac-46f5-447b-a071-63d94b858274");
        private readonly string PersonalLoanName = "John Doe";

        public LoansControllerTests()
        {
            mapperMock = mockRepository.Create<IMapper>();
            calculatorMock = mockRepository.Create<ILoanCalculator>();
            loansRepositoryMock = mockRepository.Create<ILoansRepository>();
            loansController = new LoansController(calculatorMock.Object, mapperMock.Object, loansRepositoryMock.Object);
        }

        [Fact]
        public void GetTemplateTest()
        {

            var template = loansController.GetTemplate(LoanType.Personal);

            var expected = CreatePersonalLoanModel();

            Assert.Equal(expected, template, new PersonalLoanModelComparer());
        }

        [Fact]
        public void CreateTest()
        {
            PersonalLoanModel personalLoanModel = CreatePersonalLoanModel();
            var personalLoan = new PersonalLoan(PersonalLoanName, 1, 1, 1, Payback.EveryMonth, PersonalLoanId);

            mapperMock.Setup(m => m.Map<PersonalLoan>(personalLoanModel)).Returns(personalLoan);
            loansRepositoryMock.Setup(m => m.Add(personalLoan)).Returns(personalLoan);
            mapperMock.Setup(m => m.Map<PersonalLoanModel>(personalLoan)).Returns(personalLoanModel);

            var expectedResponse = new ResponseModel<PersonalLoanModel>()
            {
                Data = personalLoanModel
            };
            var expected = new CreatedResult(nameof(LoansController.Get), expectedResponse);
            var actual = loansController.Create(expectedResponse.Data);

            Assert.Equal(
                expected,
                (CreatedResult)actual,
                GetActionResultResponsePersonalLoanModelComparer()
                );
        }

        [Fact]
        public void CreateModelValidationTest()
        {
            ModelValidationTest(loansController.Create, CreatePersonalLoanModel(100));
        }

        [Fact]
        public void GetTest()
        {
            PersonalLoanModel personalLoanModel = CreatePersonalLoanModel();
            var personalLoan = new PersonalLoan(PersonalLoanName, 1, 1, 1, Payback.EveryMonth, PersonalLoanId);
            mapperMock.Setup(m => m.Map<PersonalLoanModel>(personalLoan)).Returns(personalLoanModel);
            loansRepositoryMock.Setup(m => m.Get(PersonalLoanId)).Returns(personalLoan);
            var expectedResponse = new ResponseModel<PersonalLoanModel>()
            {
                Data = personalLoanModel
            };
            var expected = new ObjectResult(expectedResponse) { StatusCode = (int)HttpStatusCode.OK };

            var actual = loansController.Get(PersonalLoanId);

            Assert.Equal(
                expected,
                (ObjectResult)actual,
                GetActionResultResponsePersonalLoanModelComparer()
                );
        }

        [Fact]
        public void GetNotFoundTest()
        {
            loansRepositoryMock.Setup(m => m.Get(PersonalLoanId)).Returns(() => null);
            var expected = new NotFoundResult();

            var actual = loansController.Get(PersonalLoanId);

            Assert.Equal(
                expected.StatusCode,
                ((NotFoundResult)actual).StatusCode
                );
        }

        [Fact]
        public void CalculateModelValidationTest()
        {
            ModelValidationTest(loansController.Calculate, CreatePersonalLoanModel(100));
        }

        [Fact]
        public void CalculateLoanTest()
        {
            PersonalLoanModel personalLoanModel = CreatePersonalLoanModel();
            var personalLoan = new PersonalLoan(PersonalLoanName, 1, 1, 1, Payback.EveryMonth);
            mapperMock.Setup(m => m.Map<PersonalLoan>(personalLoanModel)).Returns(personalLoan);

            var loanCalculations = new LoanCalculations(1, 1, 1);
            var expectedLoanValue = new LoanCalculationsModel { Total = 100 };

            mapperMock.Setup(m => m.Map<LoanCalculationsModel>(loanCalculations)).Returns(expectedLoanValue);

            calculatorMock.Setup(c => c.Calculate(personalLoan)).Returns(loanCalculations);
            var response = loansController.Calculate(personalLoanModel);
            var actual = (ResponseModel<LoanCalculationsModel>)((ObjectResult)response).Value;
            var expected = new ResponseModel<LoanCalculationsModel> { Data = expectedLoanValue };

            Assert.Equal(expected.Data, actual.Data);
        }

        private void ModelValidationTest<TRequest>(Func<TRequest, IActionResult> action, TRequest request)
        {
            var errorMerssage = $"Error Message";
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
            var actual = action(request);

            Assert.Equal(expected, (ObjectResult)actual, GetActionResultResponseModelComparer());
        }

        private static PersonalLoanModel CreatePersonalLoanModel(decimal amount = 10000)
        {
            return new PersonalLoanModel { Amount = amount, TermMonths = 12, RatePercents = 6, Payback = Payback.EveryMonth };
        }

        private static ActionResultComparer<ResponseModel<PersonalLoanModel>> GetActionResultResponsePersonalLoanModelComparer()
        {
            return new ActionResultComparer<ResponseModel<PersonalLoanModel>>(
                new ResponseModelDataComparer<PersonalLoanModel>(
                    new PersonalLoanModelComparer(),
                    new MessageModelComparer()
                    ));
        }

        private static ActionResultComparer<ResponseModel> GetActionResultResponseModelComparer()
        {
            return new ActionResultComparer<ResponseModel>(new ResponseModelComparer(new MessageModelComparer()));
        }
    }
}