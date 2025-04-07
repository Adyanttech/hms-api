using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagementSystem.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel request)
        {
            var result = await _registerService.RegisterAsync(request);
            return Ok(new { message = result });
        }
    }
}
