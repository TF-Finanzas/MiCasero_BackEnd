using MiCasero_WebAPI.Dtos.Owner;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Mappers;
using MiCasero_WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace MiCasero_WebAPI.Controllers
{
    [Route("API/[Controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService service)
        {
            _ownerService = service;
        }
        [HttpGet]
        public async Task<IActionResult> LoginOwner(RegisterOwnerDTO ownerdto)
        {
            if (ownerdto == null)
            {
                return BadRequest();
            }
            var login = await _ownerService.Login(ownerdto);
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterOwner(RegisterOwnerDTO ownerdto)
        {
            if (await _ownerService.Register(ownerdto) == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (await _ownerService.Delete(id) == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
