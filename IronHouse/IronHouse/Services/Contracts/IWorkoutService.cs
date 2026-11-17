using IronHouse.Models;

namespace IronHouse.Services.Contracts
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutLog>> GetAllAsync();
        Task<WorkoutLog> GetByIdAsync(int id);
        Task<WorkoutLog> GetByIdWithSetsAsync(int id);
        Task CreateAsync(WorkoutLog workoutLog);
        Task UpdateAsync(WorkoutLog workoutLog);
        Task DeleteAsync(int id);
        Task<bool>ExistAsync(int id);
    }
}
