using Data.RequestModels;
using Managers.IManagers;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class CreditCardController : ControllerBase
    {
        private ICreditCardManager _creditCardManager;

        public CreditCardController(ICreditCardManager creditCardManager)
        {
            _creditCardManager = creditCardManager;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Validate")]
        public IActionResult ValidateCreditCard(CreditCardValidationDto creditCardValidationRequestModel)
        {
            try
            {
                var creditCardInfo = _creditCardManager.ValidateCreditCards(creditCardValidationRequestModel);
                return Ok(creditCardInfo);
            }
            catch (Exception ex)
            {
                //Log error message: TODO
                return BadRequest(ex.Message);
            }
        }
    }
}
