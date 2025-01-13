using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewSpace.Dto.Get.Products;
using NewSpace.Model;
using NewSpace.Service.Abstraction;

namespace NewSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineContoller : ControllerBase
    {
        private readonly Iwine wine;

        public WineContoller(Iwine wine)
        {
            this.wine = wine;
        }

        [HttpGet("Get-wine")]
        public ActionResult<List<WineDto>> GetAllwine()
        {
            return Ok(wine.GetAllWine());
        }

        [HttpPost("add-wine")]
        public ActionResult<bool> Addwine(string name, decimal price, string img, string description)
        {
            return Ok(wine.AddWine(name, price, img, description));
        }

        [HttpDelete("delete-Wine/{id}")]
        public ActionResult<bool> DeleteCoctaile(int id)
        {
            var result = wine.DeleteWine(id);
            if (!result)
            {
                return NotFound($"ID {id} was not found.");
            }

            return Ok($"{id} was successfully deleted.");
        }
    }
}
