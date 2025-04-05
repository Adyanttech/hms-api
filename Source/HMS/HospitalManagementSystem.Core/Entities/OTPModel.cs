using HospitalManagementSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class OTPModel
    {
        public string? PhoneNumber { get; set; }
        public string? Code { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsUsed { get; set; }
        public OTPFor OTPGeneratedFor { get; set; }
    }
}
