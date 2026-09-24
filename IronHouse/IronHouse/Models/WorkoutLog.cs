namespace IronHouse.Models
{
    using System.ComponentModel.DataAnnotations;
    using static IronHouse.Data.EntityValidationConstants.WorkoutLog;
    public class WorkoutLog
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        [StringLength(WorkoutTypeMaxLength)]
        [MinLength(WorkoutTypeMinLength)]
        public string WorkoutType { get; set; } = null!;

        [StringLength(NotesMaxLength)]
        public string? Notes { get; set; }

        [Required]
        [StringLength(DurationMaxLength)]
        [MinLength(DurationMinLength)]
        public string Duration { get; set; } = null!;

        [Required]
        [StringLength(CaloriesBurnedMaxLength)]
        [MinLength(CaloriesBurnedMinLength)]
        public string CaloriesBurned { get; set; } = null!;

        public ICollection<SetLog> SetLogs { get; set; } = new List<SetLog>();
    }
}
