using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities.DTO
{
    public class DoctorAppointmentsDTO
    {
        public string? PatientId { get; set; }

        public string? PatientName { get; set; }

        public string? AppointmentDate { get; set; }

        public int TokenNumber { get; set; }

        public string? PhoneNumber { get; set; }

        public bool ? IsServed { get; set; }
    }
}
