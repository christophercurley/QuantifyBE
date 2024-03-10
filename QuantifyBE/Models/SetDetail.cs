using System.Security.Cryptography.X509Certificates;

namespace QuantifyBE.Models
{
    public class SetDetail
    {
        public Guid Id { get; set; }
        public Guid RoutineExerciseDetail {  get; set; }
        public RoutineExerciseDetails RoutineExerciseDetails { get; set;}

        public int SetNumber { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
    }
}
