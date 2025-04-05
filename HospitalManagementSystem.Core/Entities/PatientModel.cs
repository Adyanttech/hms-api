using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class PatientModel : Audit
    {
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
    }
}
