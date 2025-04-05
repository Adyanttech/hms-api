using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class TokenModel : Audit
    {
        public int AppointmentId { get; set; }
        public int TokenNumber { get; set; }
        public  bool IsServed { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime ServedAt { get; set; }
    }
}
