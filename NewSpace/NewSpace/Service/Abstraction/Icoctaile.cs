using NewSpace.Dto.Get.Products;

namespace NewSpace.Service.Abstraction;

public interface Icoctaile
{
    List<CoctaileDto> GetAllCoctaile();
    bool AddCoctaile(string name, decimal price, string description, string img);
    bool DeleteCoctaile(int id);
}
