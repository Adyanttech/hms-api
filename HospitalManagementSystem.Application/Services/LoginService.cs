using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Enums;
using HospitalManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly HmsDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public LoginService(HmsDbContext context, IPasswordHasher passwordHasher) 
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> LoginAsync(LoginModel model)
        {
            switch (model.Role)
            {
                case UserRoles.SuperAdmin:
                    return await ValidateLoginAsync(model.UserName, model.Password, UserRoles.SuperAdmin);
                case UserRoles.Admin:
                    return await ValidateLoginAsync(model.UserName, model.Password, UserRoles.Admin);
                case UserRoles.Patient:
                    return await ValidateLoginAsync(model.UserName, model.Password, UserRoles.Patient);
                case UserRoles.Doctor:
                    return await ValidateLoginAsync(model.UserName, model.Password, UserRoles.Doctor);
                case UserRoles.Pharmacist:
                    //return await ValidatePharmacistAsync(request.UserName, request.Password);
                case UserRoles.LabTechnician:
                case UserRoles.SupportStaff:
                   // return await ValidateAdminAsync(request.UserName, request.Password);
                default:
                    throw new Exception("Invalid User");
            }
        }

        private async Task<string> ValidateLoginAsync(string userName, string password, UserRoles role)
        {
            dynamic? user;

            // Simple check to see if it's an email
            if (userName.Contains("@") && userName.Contains("."))
            {
                user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToString().ToLowerInvariant().Equals(userName.ToString().ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                user = await _context.Users.FirstOrDefaultAsync(u => u.Phonenumber.ToString() == userName.ToString());
            }
            bool isPasswordVerified = _passwordHasher.VerifyPassword(password, user.Passwordhash);
            if (user != null && isPasswordVerified) // simulate OTP or password match
                return "Login Successful";
            return "Invalid credentials";
        }
        
    }
}
