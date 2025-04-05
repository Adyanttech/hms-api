﻿using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Infrastructure.Context;
using HospitalManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync() => await _unitOfWork.Patients.GetAllAsync();

        public async Task<Patient> GetPatientByIdAsync(int id) => await _unitOfWork.Patients.GetByIdAsync(id);

        public async Task AddPatientAsync(PatientModel patient)
        {

            var patientDetails = new Patient()
            {
                PatientName = patient.Name,
                PatientFatherName = patient.FatherName,
                DateOfBirth = DateOnly.FromDateTime(patient.DateOfBirth),
                Gender = patient.Gender,
                Address = patient.Address
            };
            await _unitOfWork.Patients.AddAsync(patientDetails);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdatePatientAsync(PatientModel patient)
        {
            var patientDetails = new Patient()
            {
                PatientName = patient.Name,
                PatientFatherName = patient.FatherName,
                DateOfBirth = DateOnly.FromDateTime(patient.DateOfBirth),
                Gender = patient.Gender,
                ContactNumber = patient.ContactNumber,
                Address = patient.Address,
            };

            _unitOfWork.Patients.Update(patientDetails);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient != null)
            {
                _unitOfWork.Patients.Remove(patient);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
