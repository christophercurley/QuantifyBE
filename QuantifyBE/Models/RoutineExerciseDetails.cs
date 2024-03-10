namespace QuantifyBE.Models
{
    public class RoutineExerciseDetails
    {
        public Guid RoutineId { get; set; }
        public Routine Routine { get; set; }

        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }


        public int Sets { get; set; }
        public int Reps { get; set; }
        public int[] Weights { get; set; }
        public string Notes { get; set; }
    }
}
