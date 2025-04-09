using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagementSystem.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController (IDoctorService doctorService) 
        {
            _doctorService = doctorService;
        }
        // GET: api/<DoctorController>
        [HttpGet("doctorAppointments")]
        public async Task<List<DoctorAppointmentsDTO>>Get(int doctorId)
        {
          return await _doctorService.GetDoctorAppointments(doctorId);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
