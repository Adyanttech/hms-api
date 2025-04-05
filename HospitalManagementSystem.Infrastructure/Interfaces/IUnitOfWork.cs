
using HospitalManagementSystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Patient> Patients { get; }
        IBaseRepository<Doctor> Doctors { get; }
        IBaseRepository<Appointment> Appointments { get; }
        IBaseRepository<Token> Tokens { get; }
        Task<int> CompleteAsync();
    }
}
