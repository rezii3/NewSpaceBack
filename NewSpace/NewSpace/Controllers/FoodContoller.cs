using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewSpace.Dto.Get.Products;
using NewSpace.Model;
using NewSpace.Service.Abstraction;

namespace NewSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodContoller : ControllerBase
    {
        private readonly Ifood food;

        public FoodContoller(Ifood Food)
        {
            this.food = Food;
        }

        [HttpGet("Get-Food")]
        public ActionResult<List<FoodDto>> GetAllFood()
        {
            return Ok(food.GetAllFood());
        }

        [HttpPost("add-Food")]
        public ActionResult<bool> AddFood(string name, decimal price, string img, string description)
        {
            return Ok(food.AddFood(name, price, img, description));
        }

        [HttpDelete("delete-Food/{id}")]
        public ActionResult<bool> DeleteCoctaile(int id)
        {
            var result = food.DeleteFood(id);
            if (!result)
            {
                return NotFound($"ID {id} was not found.");
            }

            return Ok($"{id} was successfully deleted.");
        }
    }
}
