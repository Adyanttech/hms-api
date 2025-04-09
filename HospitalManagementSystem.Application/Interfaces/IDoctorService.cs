using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Core.Entities.DTO;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorAppointmentsDTO>> GetDoctorAppointments(int doctorId);
        Task<List<PatientDTO>> GetDoctorPatients(int doctorId);
    }
}
