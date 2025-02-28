using NewSpace.Dto.Get.Products;

namespace NewSpace.Service.Abstraction;

public interface Iwine
{
    List<WineDto> GetAllWine();
    bool AddWine(string name, decimal price, string description, string img);
    bool DeleteWine(int id);
}
