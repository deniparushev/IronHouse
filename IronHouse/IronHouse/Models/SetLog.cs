namespace IronHouse.Models
{
    using System.ComponentModel.DataAnnotations;
    using static IronHouse.Data.EntityValidationConstants.SetLog;

    public class SetLog
    {
        [Key]
        public int Id { get; set; }

        [Range(WeightMinLength, WeightMaxLength, ErrorMessage = "Weight must be between {1} kg and {2} kg.")]
        public double WeightKg { get; set; }

        [Range(RepsMinLength, RepsMaxLength, ErrorMessage = "Reps must be between {1} and {2}.")]
        public int Reps { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog? WorkoutLog { get; set; }

        [Required(ErrorMessage = "Please select an exercise.")]
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
    }
}