using Data.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.IManagers
{
    public interface ICreditCardManager
    {
        List<CreditCardInfoDto> ValidateCreditCards(CreditCardValidationDto creditCardValidation);
    }
}
