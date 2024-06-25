using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Dtos.Owner;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MiCasero_WebAPI.Controllers
{
    [Route("Api/[Controller]")]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomer(CreateCustomerDTO customerDTO)
        {
            if (await _customerService.CreateCustomer(customerDTO) == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ReadCustomer(int id)
        {
            var customers_dto= await _customerService.ReadCustomer(id);
            if (customers_dto == null)
            {
                return BadRequest();
            }
            return Ok(customers_dto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCredit(int id, decimal credit)
        {
            var customer = await _customerService.UpdateFinancial(id, credit);
            if (customer == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("Balance/{id:int}")]
        public async Task<IActionResult> UpdateBalance(int id)
        {
            await _customerService.GetBalance(id);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _customerService.DeleteCustomer(id) == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
