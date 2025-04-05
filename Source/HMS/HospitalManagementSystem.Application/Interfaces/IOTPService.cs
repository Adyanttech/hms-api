using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface IOTPService
    {
        string GenerateOTP();
        Task SendOTP(string phoneNumber, string otp, string otpGeneratedFor);
        Task<bool> VerifyOTP(string phoneNumber, string otp, string otpGeneratedFor);
    }
}
