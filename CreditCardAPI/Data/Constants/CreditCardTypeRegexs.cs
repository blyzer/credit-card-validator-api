using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Constants
{
    public class CreditCardTypeRegexs
    {
        public const string AMEX = "^(34|37)";
        public const string DISCOVER = "^(6011)";
        public const string MASTER = "^(51|52|53|54|55)";
        public const string VISA = "^(4)";
    }   
}
