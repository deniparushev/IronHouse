using IronHouse.Models;

namespace IronHouse.Services.Contracts
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise?> GetByIdAsync(int id);
        Task CreateAsync(Exercise exercise);
        Task UpdateAsync(Exercise exercise);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}