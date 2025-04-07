using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Core.Enums;

namespace HospitalManagementSystem.Core.Entities
{
    public class LoginModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; } // or OTP if you're using OTP-based login
        public UserRoles Role { get; set; } // "Patient", "Doctor", etc.
    }
}
