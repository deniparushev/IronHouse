namespace IronHouse.Models
{
    using System.ComponentModel.DataAnnotations;
    using static IronHouse.Data.EntityValidationConstants.SetLog;
    public class SetLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(WeightMaxLength)]
        [MinLength(WeightMinLength)]
        public double WeightKg { get; set; }

        [Required]
        [StringLength(RepsMaxLength)]
        [MinLength(RepsMinLength)]
        public int Reps { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog? WorkoutLog { get; set; }

        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        
    }
}
