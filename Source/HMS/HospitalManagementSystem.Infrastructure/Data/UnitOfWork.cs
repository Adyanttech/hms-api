using HospitalManagementSystem.Infrastructure.Context;
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
        private readonly Context.HospitalDbContext _context;
        private BaseRepository<Patient> _patients;
        private BaseRepository<Doctor> _doctors;
        private BaseRepository<Appointment> _appointments;
        private BaseRepository<Token> _tokens;
        public UnitOfWork(Context.HospitalDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Patient> Patients => _patients ??= new BaseRepository<Patient>(_context);

        public IBaseRepository<Doctor> Doctors => _doctors ??= new BaseRepository<Doctor>(_context);

        public IBaseRepository<Appointment> Appointments => _appointments ??= new BaseRepository<Appointment>(_context);

        public IBaseRepository<Token> Tokens => _tokens ??= new BaseRepository<Token>(_context);

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
