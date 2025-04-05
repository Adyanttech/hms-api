using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Infrastructure.Context;
using HospitalManagementSystem.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagementSystem.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork, IPatientService patientService) 
        { 
            _unitOfWork = unitOfWork;
            _patientService = patientService;
        }
        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _unitOfWork.Patients.GetAllAsync().Result;
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return _unitOfWork.Patients.GetByIdAsync(id).Result;
        }

        // POST api/<PatientController>
        [HttpPost("RegisterPatient")]
        public void Post([FromBody] PatientModel patient)
        {
            try
            {
                if (patient != null)
                {
                    _patientService.AddPatientAsync(patient);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PatientModel patient)
        {
            try
            {
                if (patient != null && id > 0)
                {
                    _patientService.UpdatePatientAsync(patient);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
