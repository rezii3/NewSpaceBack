using AutoMapper;
using NewSpace.Data;
using NewSpace.Dto.Get.Products;
using NewSpace.Model;
using NewSpace.Service.Abstraction;
using NewSpace.Service.Implementation;
namespace NewSpace.Service.Implementation;

public class IfoodService: Ifood
{
    private readonly DataContxt _context;
    private readonly IMapper mapper;

    public IfoodService(DataContxt context, IMapper mapper)
    {
        this._context = context;
        this.mapper = mapper;
    }
    public List<FoodDto> GetAllFood()
    {
        var Allfood = _context.foods.ToList();
        var MapperFood = mapper.Map<List<FoodDto>>(Allfood);

        return MapperFood;
    }
    public bool AddFood(string name, decimal price, string img, string description)
    {
        var food = new Food
        {
            Name = name,
            Price = price,
            Img = img,
            Description = description
        };
        _context.foods.Add(food);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteFood(int id) // ახალი მეთოდი წაშლისთვის
    {
        var Food = _context.foods.FirstOrDefault(c => c.Id == id); // ვეძებთ ჩანაწერს
        if (Food == null) return false; // თუ ჩანაწერი არ მოიძებნა, ვაბრუნებთ false-ს

        _context.foods.Remove(Food); // ვშლით ჩანაწერს
        _context.SaveChanges(); // ვაფიქსირებთ ცვლილებებს მონაცემთა ბაზაში
        return true; // ვაბრუნებთ true-ს წარმატების შემთხვევაში
    }


}
