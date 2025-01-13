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
    public List<CoctaileDto> GetAllTC()
    {
        var Allcoctaile = _context.coctailes.ToList();
        var MapperCoctaile = mapper.Map<List<CoctaileDto>>(Allcoctaile);

        return MapperCoctaile;
    }
    public bool AddTC(string name, decimal price, string img, string description)
    {
        var coctaile = new Coctaile
        {
            Name = name,
            Price = price,
            Img = img,
            Description = description
        };
        _context.coctailes.Add(coctaile);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteTC(int id) // ახალი მეთოდი წაშლისთვის
    {
        var teaCoffe = _context.coctailes.FirstOrDefault(c => c.Id == id); // ვეძებთ ჩანაწერს
        if (teaCoffe == null) return false; // თუ ჩანაწერი არ მოიძებნა, ვაბრუნებთ false-ს

        _context.coctailes.Remove(teaCoffe); // ვშლით ჩანაწერს
        _context.SaveChanges(); // ვაფიქსირებთ ცვლილებებს მონაცემთა ბაზაში
        return true; // ვაბრუნებთ true-ს წარმატების შემთხვევაში
    }
}
