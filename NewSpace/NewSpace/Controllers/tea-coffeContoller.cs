using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewSpace.Dto.Get.Products;
using NewSpace.Model;
using NewSpace.Service.Abstraction;

namespace NewSpace.Controllers;

[Route("api/[controller]")]
[ApiController]
public class tea_coffeContoller : ControllerBase
{
    private readonly Itea_coffe teaCoffe;

    public tea_coffeContoller(Itea_coffe teaCoffe)
    {
        this.teaCoffe = teaCoffe;
    }

    [HttpGet("Get-tea-coffe")]
    public ActionResult<List<Tea_CoffeDto>> GetAllteacoffe()
    {
        return Ok(teaCoffe.GetAllTC());
    }

    [HttpPost("add-tea-coffe")]
    public ActionResult<bool> AddFood(string name, decimal price, string img, string description)
    {
        return Ok(teaCoffe.AddTC(name, price, img, description));
    }

    [HttpDelete("delete-tea-Coffe/{id}")]
    public ActionResult<bool> DeleteCoctaile(int id)
    {
        var result = teaCoffe.DeleteTC(id);
        if (!result)
        {
            return NotFound($"ID {id} was not found.");
        }

        return Ok($"{id} was successfully deleted.");
    }
}


