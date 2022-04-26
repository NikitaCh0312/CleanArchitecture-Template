namespace DataAccess.BaseImplementation.Repositories
{
    using DataAccess.Interfaces;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class WashServicesRepository : IRepository<WashService>
    {
        private readonly DatabaseContext _context;

        public WashServicesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(List<WashService> items)
        {
            await _context.WashServices.AddRangeAsync(items);
        }

        public async Task DeleteAsync(Expression<Func<WashService, bool>> condition)
        {
            IEnumerable<WashService> removeItems = _context.WashServices
                .Include(item => item.CarWash)
                .Where(condition);
            _context.RemoveRange(removeItems);
        }

        public async Task<WashService> GetAsync(Expression<Func<WashService, bool>> condition)
        {
            return await _context.WashServices
                .Include(item => item.CarWash)
                .FirstOrDefaultAsync(condition);
        }

        public async Task<List<WashService>> GetAllAsync()
        {
            return await _context.WashServices
                .Include(item => item.CarWash)
                .ToListAsync();
        }

        public async Task<List<WashService>> GetAllAsync(Expression<Func<WashService, bool>> condition)
        {
            return await _context.WashServices
                .Include(item => item.CarWash)
                .Where(condition)
                .ToListAsync();
        }

        public async Task<List<WashService>> GetFirstAsync(Expression<Func<WashService, bool>> condition, int limit)
        {
            return await _context.WashServices
                .Include(item => item.CarWash)
                .Where(condition)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<List<WashService>> GetLastAsync(Expression<Func<WashService, bool>> condition, int limit)
        {
            return await _context.WashServices
                .Include(item => item.CarWash)
                .Where(condition)
                .TakeLast(limit)
                .ToListAsync();
        }

        public async Task UpdateAsync(WashService item)
        {
            _context.WashServices.Update(item);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
