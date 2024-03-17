using Microsoft.AspNetCore.Mvc;
using QuantifyBE.Models;
using QuantifyBE.Services;

namespace QuantifyBE.Controllers
{
    [ApiController]
    [Route("f")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IEnumerable<Food> list = await _foodService.GetAllFoodAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);

            return Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Food foodDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Food food = new Food
            {
                Name = foodDTO.Name,
                Protein = foodDTO.Protein,
                Fat = foodDTO.Fat,
                Carbohydrates = foodDTO.Carbohydrates,
                Calories = foodDTO.Calories,
            };

            var createdFood = await _foodService.CreateFoodAsync(food);
            return CreatedAtAction(nameof(GetById), new { id = createdFood.Id }, createdFood);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Food food)
        {
            var updatedFood = await _foodService.UpdateFoodAsync(food);

            if (updatedFood == null)
            {
                return NotFound();
            }

            return Ok(updatedFood);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Boolean doesExist = await _foodService.DeleteFoodByIdAsync(id);

            if (!doesExist)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
