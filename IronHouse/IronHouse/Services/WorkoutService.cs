using IronHouse.Data;
using IronHouse.Models;
using IronHouse.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IronHouse.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _context;

        public WorkoutService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkoutLog>> GetAllAsync()
        {
            return await _context.WorkoutLogs
                .AsNoTracking()
                .Include(w => w.SetLogs)
                .ThenInclude(s => s.Exercise)
                .OrderByDescending(w => w.Date)
                .ToListAsync();
        }
        public async Task<WorkoutLog?> GetByIdAsync(int id)
        {
            return await _context.WorkoutLogs               
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<WorkoutLog?> GetByIdWithSetsAsync(int id)
        {
            return await _context.WorkoutLogs
                .Include(w => w.SetLogs)
                .ThenInclude(s => s.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task CreateAsync(WorkoutLog workoutLog)
        {
            _context.WorkoutLogs.Add(workoutLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkoutLog workoutLog)
        {
            _context.WorkoutLogs.Update(workoutLog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workoutLog = await _context.WorkoutLogs.FindAsync(id);
            if (workoutLog != null)
            {
                _context.WorkoutLogs.Remove(workoutLog);
                await _context.SaveChangesAsync();
            }
        }
        public Task <bool> ExistAsync(int id)
        {
            return _context.WorkoutLogs.AnyAsync(w => w.Id == id);
        }
    }
}
