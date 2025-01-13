using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewSpace.Dto.Get.Products;
using NewSpace.Service.Abstraction;

namespace NewSpace.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoctaileController : ControllerBase
{
    private readonly Icoctaile coctaile;

    public CoctaileController (Icoctaile coctaile)
    {
        this.coctaile = coctaile;
    }

    [HttpGet("Get-Coctaile")]
    public ActionResult<List<CoctaileDto>> GetAllCoctaile()
    {
        return Ok(coctaile.GetAllCoctaile());
    }

    [HttpPost("add-coctaile")]
    public ActionResult<bool> Addcoctaile(string name,decimal price,string img, string description)
    {
        return Ok(coctaile.AddCoctaile(name, price, img , description));
    }

    [HttpDelete("delete-coctaile/{id}")]
    public ActionResult<bool> DeleteCoctaile(int id)
    {
        var result = coctaile.DeleteCoctaile(id);
        if (!result)
        {
            return NotFound($"ID {id} was not found.");
        }

        return Ok($"{id} was successfully deleted.");
    }
}
