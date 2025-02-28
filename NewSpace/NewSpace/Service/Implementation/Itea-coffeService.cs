using AutoMapper;
using NewSpace.Data;
using NewSpace.Dto.Get.Products;
using NewSpace.Model;
using NewSpace.Service.Abstraction;

namespace NewSpace.Service.Implementation;

public class Itea_coffeService:Itea_coffe
{
    private readonly DataContxt _context;
    private readonly IMapper mapper;

    public Itea_coffeService(DataContxt context, IMapper mapper)
    {
        this._context = context;
        this.mapper = mapper;
    }
    public List<Tea_CoffeDto> GetAllTC()
    {
        var AllTeaCoffe = _context.tea_coffes.ToList();
        var MapperTeaCoffe = mapper.Map<List<Tea_CoffeDto>>(AllTeaCoffe);

        return MapperTeaCoffe;
    }
    public bool AddTC(string name, decimal price, string img, string description)
    {
        var teacoffe = new Tea_Coffe
        {
            Name = name,
            Price = price,
            Img = img,
            Description = description
        };
        _context.tea_coffes.Add(teacoffe);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteTC(int id) // ახალი მეთოდი წაშლისთვის
    {
        var teaCoffe = _context.tea_coffes.FirstOrDefault(c => c.Id == id); // ვეძებთ ჩანაწერს
        if (teaCoffe == null) return false; // თუ ჩანაწერი არ მოიძებნა, ვაბრუნებთ false-ს

        _context.tea_coffes.Remove(teaCoffe); // ვშლით ჩანაწერს
        _context.SaveChanges(); // ვაფიქსირებთ ცვლილებებს მონაცემთა ბაზაში
        return true; // ვაბრუნებთ true-ს წარმატების შემთხვევაში
    }
}
