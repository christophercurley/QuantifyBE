using System.ComponentModel.DataAnnotations;

namespace QuantifyBE.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<RecipeFood> Foods { get; set; } = new List<RecipeFood>();
        public int Likes { get; set; }
    }
}
