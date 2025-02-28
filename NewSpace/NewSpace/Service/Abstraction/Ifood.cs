using NewSpace.Dto.Get.Products;

namespace NewSpace.Service.Abstraction;

public interface Ifood
{
    List<FoodDto> GetAllFood();
    bool AddFood(string name, decimal price, string description, string img);
    bool DeleteFood(int id);
}
