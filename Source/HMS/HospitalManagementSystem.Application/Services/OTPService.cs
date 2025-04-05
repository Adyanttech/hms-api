using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Enums;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;

namespace HospitalManagementSystem.Application.Services
{
    public class OTPService : IOTPService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _twilioPhoneNumber;

        public OTPService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _twilioPhoneNumber = configuration["Twilio:PhoneNumber"];
        }
        public string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public Task<bool> VerifyOTP(string phoneNumber, string otp, string otpGeneratedFor)
        {
            OTPModel existingOTPDetails = GetOTP(phoneNumber);
            if (otp != null && existingOTPDetails.Code == otp && existingOTPDetails.OTPGeneratedFor.ToString().ToLowerInvariant() == otpGeneratedFor.ToString().ToLowerInvariant() && existingOTPDetails.Expiry > DateTime.Now && !existingOTPDetails.IsUsed)
            {
                // Mark the OTP as used
                // Save changes to database
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task SendOTP(string phoneNumber, string otp, string otpGeneratedFor)
        {
            TwilioClient.Init(_accountSid, _authToken);
            string messageBody = otpGeneratedFor.ToString().Trim().ToLowerInvariant() == OTPFor.Login.ToString().Trim().ToLowerInvariant() ?
                                $"Your Mobile verification OTP for Login {otp}" : "";
            try
            {
                var message = MessageResource.Create(
                    body: messageBody,
                    from: new Twilio.Types.PhoneNumber(_twilioPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(phoneNumber)
                );

                //TODO Save OTP Details to Database
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Twilio API error: {ex.Message}");
            }
            return Task.CompletedTask;
        }

        private OTPModel GetOTP(string phoneNumber) 
        { 
            throw new NotImplementedException();
        }
    }
}
