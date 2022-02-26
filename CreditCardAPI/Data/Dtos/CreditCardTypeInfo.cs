using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class CreditCardTypeInfo
    {
        public CreditCardTypeInfo(string regex, int cardNumberLength, CreditCardTypeEnum creditCardType)
        {
            CardNumberLength = cardNumberLength;
            CreditCardType = creditCardType;
            Regex = regex;
        }

        public int CardNumberLength { get; set; }
        public CreditCardTypeEnum CreditCardType { get; set; }
        public string Regex { get; set; }
    }
}
