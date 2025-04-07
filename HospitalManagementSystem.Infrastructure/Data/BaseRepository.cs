using HospitalManagementSystem.Infrastructure.Models;
using HospitalManagementSystem.Infrastructure.Interfaces;
using HospitalManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly HmsDbContext _context;
        public BaseRepository(HmsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Remove(T entity) => _context.Set<T>().Remove(entity);
    }
}
