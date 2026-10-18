namespace IronHouse.Models
{
    using System.ComponentModel.DataAnnotations;
    using static IronHouse.Data.EntityValidationConstants.WorkoutLog;

    public class WorkoutLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Workout type is required.")]
        [StringLength(WorkoutTypeMaxLength, MinimumLength = WorkoutTypeMinLength)]
        public string WorkoutType { get; set; } = string.Empty;

        [Range(DurationMinLength, DurationMaxLength, ErrorMessage = "Duration must be between {1} and {2} minutes.")]
        public int Duration { get; set; }

        [Range(CaloriesBurnedMinLength, CaloriesBurnedMaxLength, ErrorMessage = "Calories must be between {1} and {2}.")]
        public int? CaloriesBurned { get; set; }

        [StringLength(NotesMaxLength)]
        public string? Notes { get; set; }

        public ICollection<SetLog> SetLogs { get; set; } = new List<SetLog>();
    }
}