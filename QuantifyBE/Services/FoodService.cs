using QuantifyBE.Models;
using QuantifyBE.Repositories;

namespace QuantifyBE.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRespository _foodRepository;

        public FoodService(IFoodRespository foodRespository)
        {
            _foodRepository = foodRespository;
        }

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
            var foodList = await _foodRepository.GetAllAsync();
            return foodList;
        }

        public async Task<Food> GetFoodByIdAsync(Guid id)
        {
            var food = await _foodRepository.GetByIdAsync(id);
            return food;
        }

        public async Task<Food> CreateFoodAsync(Food food)
        {
            var createdFood = await _foodRepository.CreateAsync(food);
            return createdFood;
        }

        public async Task<Food> UpdateFoodAsync(Food food)
        {
            Console.WriteLine("Food was updated!");
            return new Food();
        }

        public async Task<Boolean> DeleteFoodByIdAsync(Guid id)
        {
            var foodToBeDeleted = await _foodRepository.GetByIdAsync(id);
            if (foodToBeDeleted == null)
            {
                return false;
            }

            await _foodRepository.DeleteFoodByIdAsync(foodToBeDeleted);

            return true;
        }
    }
}
