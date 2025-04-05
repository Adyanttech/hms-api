using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class Audit
    {
        public int Id { get; set; }
        public DateTime StartDate {get; set;}
        public DateTime EndDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set;}
    }
}
