using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Dtos.Transfer;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MiCasero_WebAPI.Controllers
{
    [Route("Api/[Controller]")]
    public class TransferController:ControllerBase
    {
        private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }
        [HttpPost]
        public async Task<IActionResult> PostTransfer(CreateTransferDTO transferDTO)
        {
            if (await _transferService.CreateTranfer(transferDTO) == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ReadTransfer(int id)
        {
            var transfers_dto = await _transferService.ReadTransfer(id);
            if (transfers_dto == null)
            {
                return BadRequest();
            }
            return Ok(transfers_dto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTransfer(int id)
        {
            if (await _transferService.DeleteTransfer(id) == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
