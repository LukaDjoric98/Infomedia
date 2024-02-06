using Infomedia.Server.Helpers;
using Infomedia.Server.Models.RequestDto;
using Infomedia.Server.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infomedia.Server.Controllers
{
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IQueries _queries;

        public PurchaseController(IQueries queries)
        {
            _queries = queries;
        }

        [HttpPost(Name = "PurchaseUsingPhoneAndPin")]
        public async Task<IActionResult> PurchaseUsingPhoneAndPin([FromBody] PurchaseInputDto inputDto)
        {
            // Checking if MSISDN and PIN are not null
            if (!Value.Check(inputDto.MSISDN) && !Value.Check(inputDto.PIN))
            {
                return NotFound();
            }

            // Making a purchase transaction 
            var purchaseResponse = await _queries.PurchaseTransactionAsync(inputDto);

            // Sending notification
            await _queries.SendNotificationAsync(purchaseResponse);

            return Ok();
        }
    }
}
