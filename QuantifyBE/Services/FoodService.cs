using QuantifyBE.Models;

namespace QuantifyBE.Services
{
    public class FoodService : IFoodService
    {
        Food chickenBreast = new Food
        {
            Id = Guid.NewGuid(),
            Name = "Chicken Breast",
            Calories = 100,
            Protein = 40f,
            Fat = 8f,
            Carbohydrates = 12f
        };

        Food beef = new Food
        {
            Id = Guid.NewGuid(),
            Name = "Chicken Breast",
            Calories = 120,
            Protein = 48f,
            Fat = 22f,
            Carbohydrates = 7f
        };

        public async Task<IEnumerable<Food>> GetAllFoodAsync()
        {
            List<Food> foodList = new List<Food>
            {
                chickenBreast, beef
            };

            return foodList;
        }

        public async Task<Food> GetFoodByIdAsync(Guid id)
        {
            Console.Write($"Here's yo food: {id}");
            return new Food();
        }

        public async Task<Food> CreateFoodAsync(Food food)
        {
            Console.WriteLine("Food was created nigga!");
            return new Food();
        }

        public async Task<Food> UpdateFoodAsync(Food food)
        {
            Console.WriteLine("Food was updated!");
            return new Food();
        }

        public async Task DeleteFoodByIdAsync(Guid id)
        {
            Console.WriteLine("Food was deleted!");
        }
    }
}
