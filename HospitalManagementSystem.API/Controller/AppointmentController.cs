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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork, IAppointmentService appointmentService) 
        {
            _unitOfWork = unitOfWork;
            _appointmentService = appointmentService;
        }
        // GET: api/<AppointmentController>
        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            return _unitOfWork.Appointments.GetAllAsync().Result.Where(t => t.AppointmentDateTime?.Date == DateTime.Today);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Appointment Get(int id)
        {
            return _unitOfWork.Appointments.GetByIdAsync(id).Result;
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] AppointmentModel appointment)
        {
            _appointmentService.AddAppointmentAsync(appointment);
        }
    }
}
