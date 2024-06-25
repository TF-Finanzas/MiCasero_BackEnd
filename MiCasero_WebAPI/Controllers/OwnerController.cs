using MiCasero_WebAPI.Dtos.Owner;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Mappers;
using MiCasero_WebAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace MiCasero_WebAPI.Controllers
{
    [Route("API/[Controller]")]
    [EnableCors("AllowAll")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService service)
        {
            _ownerService = service;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginOwner([FromBody] RegisterOwnerDTO ownerdto)
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
        [Route("Register")]
        public async Task<IActionResult> RegisterOwner([FromBody] RegisterOwnerDTO ownerdto)
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
