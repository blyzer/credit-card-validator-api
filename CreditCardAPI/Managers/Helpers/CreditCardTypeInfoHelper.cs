using Data.Constants;
using Data.Dtos;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Helpers
{
    public static class CreditCardTypeInfoHelper
    {
        public static CreditCardTypeInfo[] CreditCardTypeInfoList =
        {
              new CreditCardTypeInfo(CreditCardTypeRegexs.AMEX, CreditCardTypeLengths.AMEX, CreditCardTypeEnum.Amex),
              new CreditCardTypeInfo(CreditCardTypeRegexs.DISCOVER, CreditCardTypeLengths.DISCOVER, CreditCardTypeEnum.Discover),
              new CreditCardTypeInfo(CreditCardTypeRegexs.MASTER, CreditCardTypeLengths.MASTER, CreditCardTypeEnum.MasterCard),
              new CreditCardTypeInfo(CreditCardTypeRegexs.VISA, CreditCardTypeLengths.VISA_1, CreditCardTypeEnum.Visa),
              new CreditCardTypeInfo(CreditCardTypeRegexs.VISA, CreditCardTypeLengths.VISA_2, CreditCardTypeEnum.Visa)
        };
    }
}
