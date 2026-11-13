using IronHouse.Data;
using IronHouse.Models;
using IronHouse.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IronHouse.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _context.Exercises
                .AsNoTracking()
                .OrderBy(e => e.MuscleGroup)
                .ThenBy(e => e.Name)
                .ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.         
               FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Exercises.AnyAsync(e => e.Id == id);
        }    
    }
}
