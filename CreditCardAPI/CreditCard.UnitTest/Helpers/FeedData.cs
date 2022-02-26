using Data.Enums;
using Data.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.UnitTest.Helpers
{
    public static class FeedData
    {
        public static List<CreditCardInfoDto> GetTestCreditCardInfo()
        {
            return new List<CreditCardInfoDto>()
            {
                new CreditCardInfoDto()
                {
                    CreditCardNumberText =  "4111111111111111",
                    FormattedCreditCardNumber = "4111111111111111",
                    CreditCardType = CreditCardTypeEnum.Visa.ToString(),
                    IsValidCreditCard = true                }
            };
        }

        public static CreditCardValidationDto SendTestCreditCardList()
        {
            return new CreditCardValidationDto()
            {
                CreditCardNumbers = new List<string>()
                {
                    "4111111111111111"
                }
            };
        }
    }
}
