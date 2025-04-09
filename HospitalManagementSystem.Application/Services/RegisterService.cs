using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Enums;
using HospitalManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly HmsDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public RegisterService(HmsDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> RegisterAsync(RegisterModel request)
        {
            // Check if user already exists
            string? userRole = string.Empty;
            var userExists = await _context.Users.AnyAsync(u => u.Email == request.Email || u.Phonenumber == request.PhoneNumber);
            if (userExists) return "User already exists.";
            if (request != null)
            {
                // Create user entity
                var user = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Phonenumber = request.PhoneNumber,
                    Passwordhash = _passwordHasher.HashPassword(request.PasswordHash)
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                userRole = request.UserRole == null ? UserRoles.Patient.ToString() : request.UserRole.ToString();

                var role = await _context.Roles
                           .Where(r => r.Name != null && r.Name.ToLower() == userRole!.ToLower())
                           .FirstOrDefaultAsync();

                // Add entry in userrolesmap (many-to-many bridge table)
                var roleObj = await _context.Roles.FindAsync(role?.Id);

                if (roleObj != null)
                {
                    user.Roles.Add(roleObj);
                    await _context.SaveChangesAsync();
                }
                return "User registered successfully";
            }
            return "Invalid User";
        }
    }
}
