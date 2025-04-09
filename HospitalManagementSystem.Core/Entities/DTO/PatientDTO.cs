using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities.DTO
{
    public class PatientDTO
    {
        public string? PatientId { get; set; }

        public string? PatientName { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
