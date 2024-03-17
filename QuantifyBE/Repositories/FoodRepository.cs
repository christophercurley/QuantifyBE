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

        public async Task<Food> UpdateFoodAsync(Food food)
        {
            return new Food();
        }

        public async Task DeleteFoodByIdAsync(Food food)
        {
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }
    }
}
