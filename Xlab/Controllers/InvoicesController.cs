using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Xlab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        #region Dependency Injection

        private readonly IInvoiceService _invoice;

        public InvoicesController(IInvoiceService invoice)
        {
            _invoice = invoice;
        }

        #endregion

        #region Get Endpiont

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetInvoiceAsync(string id)
        {
            if (id == null)
            {
                return BadRequest("id is required");
            }

            var result = await _invoice.GetInvoiceAsync(id);
            if (result == null)
            {
                return BadRequest("No Invoice For This ID");
            }
            return Ok(result);
        }

        #endregion

        #region Post Endpoint

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddInvoiceAsync([FromBody]InvoiceDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invoice.AddInvoiceAsync(model);

            if (result == null)
            {
                return BadRequest("Something went wrong while adding ...");
            }

            return StatusCode(201);
        }

        #endregion

        #region Update Endpoint

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateInvoiceAsync([FromBody] InvoiceDTO model, [FromQuery] string id)
        {
            if (id != model.InvoiceId)
            {
                return BadRequest("Id Not match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invoice.UpdateInvoiceAsync(model, id);

            
            if (result == null)
            {
                return BadRequest("Something went wrong while updating ...");
            }

            return Ok(result);
        }

        #endregion

        #region Delete Endpoint

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteInvoiceAsync(string id)
        {
            if (id == null)
            {
                return BadRequest("id is required");
            }

            var result = await _invoice.DeleteInvoiceAsync(id);

            if (!result)
            {
                return NotFound("Invalid Invoice ID");
            }

            return NoContent();
        }

        #endregion
    }
}
