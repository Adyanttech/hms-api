﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
    }
}
