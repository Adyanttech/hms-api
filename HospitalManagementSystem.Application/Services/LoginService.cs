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
            if(model == null) throw new ArgumentNullException(nameof(model));
            return await ValidateLoginAsync(model);
        }

        private async Task<string> ValidateLoginAsync(LoginModel model)
        {
            User? user;
            if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                // Simple check to see if it's an email
                if (model.UserName.Contains("@") && model.UserName.Contains("."))
                {
                    user = await _context.Users
                          .Include(u => u.Roles)
                          .FirstOrDefaultAsync(u => u.Email.ToLower() == model.UserName.ToLower());
                }
                else
                {
                    user = await _context.Users
                            .Include(u => u.Roles)
                            .FirstOrDefaultAsync(u => u.Phonenumber == model.UserName);
                }
                bool isPasswordVerified = _passwordHasher.VerifyPassword(model.Password, user.Passwordhash);
                if (isPasswordVerified)
                {
                    var roleNames = user.Roles.Select(r => r.Name).ToList();
                    string roles = string.Join(", ", roleNames);
                    return roles;
                }
            }
            return "Invalid credentials";
        }
        
    }
}
