using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalContext _context;
        private BaseRepository<Patient> _patients;
        private BaseRepository<Doctor> _doctors;
        private BaseRepository<Appointment> _appointments;

        public UnitOfWork(HospitalContext context)
        {
            _context = context;
        }

        public IBaseRepository<Patient> Patients => _patients ??= new BaseRepository<Patient>(_context);

        public IBaseRepository<Doctor> Doctors => _doctors ??= new BaseRepository<Doctor>(_context);

        public IBaseRepository<Appointment> Appointments => _appointments ??= new BaseRepository<Appointment>(_context);

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
