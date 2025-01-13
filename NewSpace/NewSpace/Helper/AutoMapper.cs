using AutoMapper;
using NewSpace.Dto.Get.Products;
using NewSpace.Model;
using NewSpace.Service.Abstraction;
using NewSpace.Service.Implementation;
namespace NewSpace.Helper;

public class AutoMapper :Profile
{
    public AutoMapper() { 
       CreateMap<Coctaile,CoctaileDto>();
        CreateMap<Food,FoodDto>();
        CreateMap<Tea_Coffe, Tea_CoffeDto>();
        CreateMap<Wine, WineDto>();
    }
}
