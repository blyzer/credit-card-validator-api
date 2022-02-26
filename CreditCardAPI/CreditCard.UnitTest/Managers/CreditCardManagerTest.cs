using CreditCard.UnitTest.Helpers;
using CreditCardAPI.Controllers;
using Data.RequestModels;
using Managers.IManagers;
using Managers.Managers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CreditCard.UnitTest
{
    public class CreditCardManagerTest
    {
        private CreditCardManager _creditCardManager; 

        [Fact()]
        public void Should_ReturnValidCreditCardInfo_When_ValidateCreditCard()
        {
            _creditCardManager = new CreditCardManager();

            var creditCardInfo = _creditCardManager.ValidateCreditCards(FeedData.SendTestCreditCardList()) as List<CreditCardInfoDto>;

            Assert.NotNull(creditCardInfo);
            Assert.True(creditCardInfo.FirstOrDefault().IsValidCreditCard);
        }
    }
}