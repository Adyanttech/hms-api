using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities.DTO;
using HospitalManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HmsDbContext _context;
        public DoctorService(HmsDbContext context) 
        { 
            _context = context;
        }
        public async Task<List<DoctorAppointmentsDTO>> GetDoctorAppointments(int doctorId)
        {
            var doctor = await _context.Doctors.AnyAsync( d =>d.DoctorId == doctorId);
            List<DoctorAppointmentsDTO> listDoctorAppointments = new List<DoctorAppointmentsDTO>();
            if (doctor)
            {
                 listDoctorAppointments =  await (from appt in _context.Appointments
                                                join patient in _context.Patients on appt.PatientId equals patient.PatientId
                                                join token in _context.Tokens on appt.AppointmentId equals token.Appointmentid
                                                where appt.DoctorId == doctorId && appt.AppointmentDatetime == DateTime.Today && !(token.Isserved) // Filter for a specific doctor
                                                select new DoctorAppointmentsDTO
                                                {
                                                    PatientId = patient.PatientId.ToString(),
                                                    PatientName = patient.PatientName,
                                                    PhoneNumber = patient.ContactNumber,
                                                    AppointmentDate = appt.AppointmentDatetime!.Value.Date.ToShortDateString(),
                                                    TokenNumber = token.Tokennumber,
                                                    IsServed    = token.Isserved
                                                }).ToListAsync();
            }

            return listDoctorAppointments;
        }

        public async Task<List<PatientDTO>> GetDoctorPatients(int doctorId)
        {
            var doctor = await _context.Doctors.AnyAsync(d => d.DoctorId == doctorId);
            List<PatientDTO> listDoctorPatients = new List<PatientDTO>();
            if (doctor)
            {
                listDoctorPatients = await(from appt in _context.Appointments
                                               join patient in _context.Patients on appt.PatientId equals patient.PatientId
                                               where appt.DoctorId == doctorId // Filter for a specific doctor
                                               select new PatientDTO
                                               {
                                                   PatientId = patient.PatientId.ToString(),
                                                   PatientName = patient.PatientName,
                                                   PhoneNumber = patient.ContactNumber
                                               }).ToListAsync();
            }

            return listDoctorPatients;
        }
    }
}
