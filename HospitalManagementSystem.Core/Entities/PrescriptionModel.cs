using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class PrescriptionModel
    {
        public string? PatientName { get; set; }

        public string? DoctorName { get; set; }

        public List<string>? Medications { get; set; }

        public string? WhentoTake { get; set; }

        public string? Duration { get; set; }

        public string? Remarks { get; set; }

        public string? PrescribedLabTests { get; set; }

        public string? Advice { get; set; }

        public string? FollowUp { get; set; }
    }
}
