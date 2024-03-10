namespace QuantifyBE.Models
{
    public class RoutineExerciseDetails
    {
        public Guid RoutineId { get; set; }
        public Routine Routine { get; set; }

        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }


        public List<SetDetail> SetDetails { get; set; }
        public string Notes { get; set; }

        public RoutineExerciseDetails()
        {
            SetDetails = new List<SetDetail>();
        }
    }
}
