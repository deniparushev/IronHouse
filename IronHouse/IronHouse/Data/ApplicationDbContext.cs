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

            /* modelBuilder.Entity<WorkoutLog>()
                 .HasMany(w => w.SetLogs)
                 .WithOne(s => s.WorkoutLog)
                 .HasForeignKey(s => s.WorkoutLogId)
                 .OnDelete(DeleteBehavior.Cascade);
            */
            modelBuilder.Entity<Exercise>().HasData
            (
                new Exercise
                {
                    Id = 1,
                    Name = "Bench Press",
                    MuscleGroup = "Chest",
                    Description = "A chest exercise performed by pressing a weight upwards from a supine position."
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Squat",
                    MuscleGroup = "Legs",
                    Description = "A lower body exercise that primarily targets the thighs and glutes."
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Deadlift",
                    MuscleGroup = "Back",
                    Description = "A compound movement that targets multiple muscle groups, including the back, legs, and core."
                },
                new Exercise
                {
                   Id=4,
                   Name = "Overhead Press",
                   MuscleGroup = "Shoulders",
                   Description = "A shoulder exercise performed by pressing a weight overhead from shoulder height."
                },
                new Exercise
                {
                    Id = 5,
                    Name = "Pull-up",
                    MuscleGroup = "Back",
                    Description = "A bodyweight back exercise that targets the lats and rhomboids."
                }           
            );
        }
    }
}