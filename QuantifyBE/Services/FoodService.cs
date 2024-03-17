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

        public async Task<Food?> UpdateFoodAsync(Food food)
        {
            var updatedFood = await _foodRepository.UpdateFoodAsync(food);

            if (updatedFood == null)
            {
                return null;
            }

            return updatedFood;
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
