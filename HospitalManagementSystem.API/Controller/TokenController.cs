using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagementSystem.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        // GET api/<TokenController>/5
        [HttpGet("LiveStatus")]
        public IActionResult GetLiveTokenStatus()
        {
            var status = _tokenService.GetLiveTokenStatus();
            return Ok(status);
        }

        //// POST api/<TokenController>
        //[HttpPost("Generate")]
        //public IActionResult GenerateToken([FromBody] int appointmentId)
        //{
        //    //int tokenNumber = _tokenService.GenerateToken(appointmentId);
        //    //return Ok(new { TokenNumber = tokenNumber });

        //    return Ok();
        //}

        // PUT api/<TokenController>/5
        [HttpPut("{id}")]
        public void put(int tokenId)
        {
            var token = _unitOfWork.Tokens.GetByIdAsync(tokenId).Result;
            if (token != null && !token.Isserved)
            {
                token.Isserved = true;
                token.Servedat = DateTime.Now;
                _unitOfWork.CompleteAsync();
            }
        }
    }
}
