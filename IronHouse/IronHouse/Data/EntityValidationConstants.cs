namespace IronHouse.Data
{
    public class EntityValidationConstants
    {
        public static class Exercise
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int MuscleGroupMinLength = 2;
            public const int MuscleGroupMaxLength = 30;

            public const int DescriptionMaxLength = 500;
        }
        public static class WorkoutLog
        {
            public const int WorkoutTypeMinLength = 2;
            public const int WorkoutTypeMaxLength = 50;

            public const int NotesMaxLength = 350;

            public const int DurationMinLength = 1;
            public const int DurationMaxLength = 500;

            public const int CaloriesBurnedMinLength = 1;
            public const int CaloriesBurnedMaxLength = 1000;
        }
        public static class SetLog
        {
            public const int RepsMinLength = 1;
            public const int RepsMaxLength = 100;

            public const int WeightMinLength = 0;
            public const int WeightMaxLength = 1000;
        }
    }
}
