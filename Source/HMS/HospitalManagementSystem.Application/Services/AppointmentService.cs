using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Enums;
using HospitalManagementSystem.Infrastructure.Context;
using HospitalManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public AppointmentService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public Task AddAppointmentAsync(AppointmentModel appointment)
        {
            // Step 1: Save appointment Data
            var appointmentDetails = new Appointment
            {
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDateTime = appointment.AppointmentDate,
                AppointmentType = appointment.AppointmentType,
            };
            _unitOfWork.Appointments.AddAsync(appoinmentDetails);

            // Step 2: Payment Service

            // Step 3: Generate Token

            // Fetch lastest appointment id by using patientId
            //int appointmentId = _unitOfWork.Appointments.;
            _tokenService.GenerateToken(0);
            throw new NotImplementedException();
        }
    }
}
