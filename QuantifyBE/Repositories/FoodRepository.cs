using QuantifyBE.Data;
using QuantifyBE.Models;
using Microsoft.EntityFrameworkCore;

namespace QuantifyBE.Repositories
{
    public class FoodRepository : IFoodRespository
    {
        private readonly QuantifyDbContext _context;

        public FoodRepository(QuantifyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            var foodList = _context.Foods;
            return foodList;
        }

        public async Task<Food> GetByIdAsync(Guid id)
        {
            var food = await _context.Foods.FirstOrDefaultAsync(food => food.Id == id);
            return food;
        }

        public async Task<Food> CreateAsync(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<Food?> UpdateFoodAsync(Food food)
        {
            var foodToBeChanged = await GetByIdAsync(food.Id);

            if(foodToBeChanged != null)
            {
                foodToBeChanged.Name = food.Name;
                foodToBeChanged.Protein = food.Protein;
                foodToBeChanged.Carbohydrates = food.Carbohydrates;
                foodToBeChanged.Fat = food.Fat;
                foodToBeChanged.Calories = food.Calories;

                await _context.SaveChangesAsync();
                return foodToBeChanged;
            }
            return null;
        }

        public async Task DeleteFoodByIdAsync(Food food)
        {
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }
    }
}
