using Microsoft.AspNetCore.Mvc;

namespace QuantifyBE.Controllers
{
    [ApiController]
    [Route("f")]
    public class FoodController : ControllerBase
    {

        [HttpGet]
        public IActionResult List()
        {
            return Ok("List OK!");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok($"GetById OK! Id: {id}");
        }

        [HttpPost("{id}")]
        public IActionResult Create(Guid id)
        {
            return Ok($"AddFood OK! Id: {id}");
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id)
        {
            return Ok($"Edit OK! Id: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok($"Delete OK! Id: {id}");
        }
    }
}
