using QuantifyBE.Models;

namespace QuantifyBE.Repositories
{
    public interface IFoodRespository
    {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food> GetByIdAsync(Guid id);
        Task<Food> CreateAsync(Food food);
        Task<Food> UpdateFoodAsync(Food food);
        Task DeleteFoodByIdAsync(Guid id);
    }
}
