using QuantifyBE.Models;

namespace QuantifyBE.Services
{
    public interface IFoodService
    {
        Task<IEnumerable<Food>> GetAllFoodAsync();
        Task<Food> GetFoodByIdAsync(Guid id);
        Task<Food> CreateFoodAsync(Food food);
        Task<Food> UpdateFoodAsync(Food food);
        Task DeleteFoodByIdAsync(Guid id);
    }
}
