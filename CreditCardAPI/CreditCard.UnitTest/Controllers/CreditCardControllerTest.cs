using CreditCard.UnitTest.Helpers;
using CreditCardAPI.Controllers;
using Data.RequestModels;
using Managers.IManagers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CreditCard.UnitTest
{
    public class CreditCardControllerTest
    {
        private readonly Mock<ICreditCardManager> _creditCardManagerMock = new();
        private CreditCardController _creditCardController; 

        public CreditCardControllerTest()
        {
            //mock credit card manager ValidateCreditCards method
            _creditCardManagerMock.Setup(x => x.ValidateCreditCards(It.IsAny<CreditCardValidationDto>()))
                .Returns(FeedData.GetTestCreditCardInfo());
        }

        [Fact()]
        public void Should_ReturnValidCreditCardInfo_When_ValidateCreditCard()
        {
            _creditCardController = new CreditCardController(_creditCardManagerMock.Object);

            var actionResult = _creditCardController.ValidateCreditCard(FeedData.SendTestCreditCardList()) as OkObjectResult;
            var result = actionResult.Value as List<CreditCardInfoDto>;

            Assert.NotNull(result);
            Assert.True(result.FirstOrDefault().IsValidCreditCard);
        }
    }
}