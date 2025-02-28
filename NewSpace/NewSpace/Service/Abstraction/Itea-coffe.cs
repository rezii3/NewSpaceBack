using NewSpace.Dto.Get.Products;

namespace NewSpace.Service.Abstraction;

public interface Itea_coffe
{
    List<Tea_CoffeDto> GetAllTC();
    bool AddTC(string name, decimal price, string description, string img);
    bool DeleteTC(int id);
}
