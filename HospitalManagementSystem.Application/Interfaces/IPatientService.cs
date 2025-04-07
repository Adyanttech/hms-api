using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task AddPatientAsync(PatientModel patient);
        Task UpdatePatientAsync(PatientModel patient);
        Task DeletePatientAsync(int id);
    }
}
