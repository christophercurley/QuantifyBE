using System.ComponentModel.DataAnnotations;

namespace QuantifyBE.Models
{
    public class Food
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Protein { get; set; }
        public float Fat {  get; set; }
        public float Carbohydrates { get; set; }
        public int Calories { get; set; }
    }
}
