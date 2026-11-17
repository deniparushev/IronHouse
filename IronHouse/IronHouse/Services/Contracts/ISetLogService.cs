using IronHouse.Models;

namespace IronHouse.Services.Contracts
{
    public interface ISetLogService
    {
        Task<SetLog?> GetByIdAsync(int id);
        Task CreateAsync(SetLog setLog);
        Task UpdateAsync(SetLog setLog);
        Task DeleteAsync(int id);
        Task<bool> WorkoutExistsAsync(int workoutLogId);
        Task<bool> ExistsAsync(int id);
    }
}
