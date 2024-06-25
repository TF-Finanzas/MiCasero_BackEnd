using MiCasero_WebAPI.Dtos.Bill;
using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MiCasero_WebAPI.Controllers
{
    [Route("Api/[Controller]")]
    [EnableCors("AllowAll")]
    public class BillController:ControllerBase
    {
        private readonly IBillService _billService;
        private readonly ITransferService _transferService;
        public BillController(IBillService billService, ITransferService transferService)
        {
            _billService = billService;
            _transferService = transferService;
        }
        [HttpPost]
        public async Task<IActionResult> PostBill([FromBody] CreateBillDTO billDTO)
        {
            if (await _billService.CreateBill(billDTO) == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("Nominal/{id:int}")]
        public async Task<IActionResult> ReadNominalInterest(int id)
        {
            decimal interest = await _billService.NominalRate(id);
            if (interest == 0)
            {
                return BadRequest("Interest calculation failed or resulted in zero.");
            }
            var transfer = await _transferService.CreateInterest(interest, id);
            return Ok();
        }
        [HttpGet("Effective/{id:int}")]
        public async Task<IActionResult> ReadEffectiveInterest(int id)
        {
            decimal interest = await _billService.EffectiveRate(id);
            if (interest == 0)
            {
                return BadRequest("Interest calculation failed or resulted in zero.");
            }
            var transfer = await _transferService.CreateInterest(interest, id);
            return Ok();
        }
        [HttpGet("French/{id:int}")]
        public async Task<IActionResult> ReadFrenchMethod(int id)
        {
            List<decimal> interests = await _billService.FrenchMethod(id);
            if (interests == null)
            {
                return BadRequest("Interest calculation failed or resulted in zero.");
            }
            foreach (var interest in interests)
            {
                var transfer = await _transferService.CreateInterest(interest, id);
            }
            return Ok();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ReadBill(int id)
        {
            var bills_dto = await _billService.ReadBill(id);
            if (bills_dto == null)
            {
                return BadRequest();
            }
            return Ok(bills_dto);
        }
        [HttpPut("Balance/{id:int}")]
        public async Task<IActionResult> UpdateBalance(int id)
        {
            await _billService.UpdateBalance(id);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            if (await _billService.DeleteBill(id) == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
