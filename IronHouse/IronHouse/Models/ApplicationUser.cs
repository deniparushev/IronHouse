using Microsoft.AspNetCore.Identity;

namespace IronHouse.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
    }
}