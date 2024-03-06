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

        public int Likes { get; set; }
    }
}
