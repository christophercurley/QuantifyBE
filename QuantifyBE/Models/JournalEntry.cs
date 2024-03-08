using Microsoft.AspNetCore.Identity;

namespace QuantifyBE.Models
{
    public class JournalEntry
    {
        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }

        // User ralationship
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }


        // Optional Food Relationship
        public Guid? FoodId { get; set; }
        public Food Food { get; set; }


        //Optional Recipe relationship
        public Guid? RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
