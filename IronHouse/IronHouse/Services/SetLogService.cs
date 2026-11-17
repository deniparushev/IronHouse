using IronHouse.Data;
using IronHouse.Models;
using IronHouse.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IronHouse.Services
{
    public class SetLogService : ISetLogService
    {
        private readonly ApplicationDbContext _context;

        public SetLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SetLog?> GetByIdAsync(int id)
        {
            return await _context.SetLogs
                .Include(s => s.Exercise)
                .Include(s => s.WorkoutLog)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateAsync(SetLog setLog)
        {
            await _context.SetLogs.AddAsync(setLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SetLog setLog)
        {
            _context.SetLogs.Update(setLog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var setLog = await _context.SetLogs.FindAsync(id);
            if (setLog != null)
            {
                _context.SetLogs.Remove(setLog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> WorkoutExistsAsync(int workoutLogId)
        {
            return await _context.WorkoutLogs.AnyAsync(w => w.Id == workoutLogId);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SetLogs.AnyAsync(s => s.Id == id);
        }
    }
}
