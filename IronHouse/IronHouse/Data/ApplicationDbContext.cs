using IronHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace IronHouse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<WorkoutLog> WorkoutLogs { get; set; } = null!;
        public DbSet<SetLog> SetLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<SetLog>()
                .HasOne(s => s.WorkoutLog)
                .WithMany(w => w.SetLogs)
                .HasForeignKey(s => s.WorkoutLogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetLog>()
                .HasOne(s => s.Exercise)
                .WithMany(e => e.SetLogs)
                .HasForeignKey(s => s.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}