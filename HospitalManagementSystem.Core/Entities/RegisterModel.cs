using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Core.Enums;

namespace HospitalManagementSystem.Core.Entities
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string PasswordHash { get; set; }
        public UserRoles? Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
