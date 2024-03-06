namespace QuantifyBE.Models
{
    public class RecipeFood
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public Guid FoodId { get; set; }
        public Food Food { get; set; }

        // Additional property for quantity
        public float Quantity { get; set; }
    }
}
