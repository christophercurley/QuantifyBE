namespace QuantifyBE.Models
{
    public class UserRoutineLogs
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid RoutineId { get; set; }
        public Routine Routine { get; set; }

        public bool IsComplete { get; set; }
        public DateTime Date { get; set; }
    }
}
