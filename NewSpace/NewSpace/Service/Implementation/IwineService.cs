using AutoMapper;
using NewSpace.Data;
using NewSpace.Dto.Get.Products;
using NewSpace.Model;
using NewSpace.Service.Abstraction;

namespace NewSpace.Service.Implementation;

public class IwineService:Iwine
{
    private readonly DataContxt _context;
    private readonly IMapper mapper;

    public IwineService(DataContxt context, IMapper mapper)
    {
        this._context = context;
        this.mapper = mapper;
    }
    public List<CoctaileDto> GetAllWine()
    {
        var Allcoctaile = _context.coctailes.ToList();
        var MapperCoctaile = mapper.Map<List<CoctaileDto>>(Allcoctaile);

        return MapperCoctaile;
    }
    public bool AddWine(string name, decimal price, string img, string description)
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
    public bool DeleteWine(int id) // ახალი მეთოდი წაშლისთვის
    {
        var Wine = _context.coctailes.FirstOrDefault(c => c.Id == id); // ვეძებთ ჩანაწერს
        if (Wine == null) return false; // თუ ჩანაწერი არ მოიძებნა, ვაბრუნებთ false-ს

        _context.coctailes.Remove(Wine); // ვშლით ჩანაწერს
        _context.SaveChanges(); // ვაფიქსირებთ ცვლილებებს მონაცემთა ბაზაში
        return true; // ვაბრუნებთ true-ს წარმატების შემთხვევაში
    }
}
