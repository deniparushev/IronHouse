namespace IronHouse.Models
{
    using System.ComponentModel.DataAnnotations;
    using static IronHouse.Data.EntityValidationConstants.Exercise;
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(MuscleGroupMaxLength)]
        [MinLength(MuscleGroupMinLength)]
        public string MuscleGroup { get; set; } = null!;

        [StringLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public ICollection<SetLog> SetLogs { get; set; } = new List<SetLog>();
    }
}
