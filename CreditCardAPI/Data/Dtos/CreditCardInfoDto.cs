using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RequestModels
{
    public class CreditCardInfoDto
    {
        public string CreditCardNumberText { get; set; }
        public string FormattedCreditCardNumber { get; set; }
        public bool IsValidCreditCard { get; set; }
        public string CreditCardType { get; set; }
    }
}
