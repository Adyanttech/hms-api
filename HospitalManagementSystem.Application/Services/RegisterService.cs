using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
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
            var userExists = await _context.Users.AnyAsync(u => u.Email == request.Email);
            if (userExists) return "User already exists.";
            if (request != null)
            {
                // Create user entity
                var user = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Phonenumber = request.PhoneNumber,
                    Passwordhash = _passwordHasher.HashPassword(request.PasswordHash),
                    CreatedAt = DateTime.Now
                };
                _context.Users.Add(user);
            }
            
            await _context.SaveChangesAsync();

            return "User registered successfully";
        }
    }
}
