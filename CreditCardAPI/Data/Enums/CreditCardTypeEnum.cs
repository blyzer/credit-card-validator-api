using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum CreditCardTypeEnum
    {
        [Description("Amex")]
        Amex = 1,

        [Description("Discover")]
        Discover,

        [Description("Master Card")]
        MasterCard,

        [Description("Visa")]
        Visa,

        [Description("Unknown")]
        Unknown
    }
}
