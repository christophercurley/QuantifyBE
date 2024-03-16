using QuantifyBE.Data;
using QuantifyBE.Models;

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
            return new Food[0];
        }

        public async Task<Food> GetByIdAsync(Guid id)
        {
            return new Food();
        }

        public async Task<Food> CreateAsync(Food food)
        {
            _context.Add(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<Food> UpdateFoodAsync(Food food)
        {
            return new Food();
        }

        public async Task DeleteFoodByIdAsync(Guid id)
        {

        }
    }
}
