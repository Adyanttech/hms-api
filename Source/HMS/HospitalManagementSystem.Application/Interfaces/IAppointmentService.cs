﻿using HospitalManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task AddAppointmentAsync(AppointmentModel appointment);

    }
}
