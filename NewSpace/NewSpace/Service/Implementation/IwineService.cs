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
    public List<WineDto> GetAllWine()
    {
        var AllWine = _context.wines.ToList();
        var MapperWine = mapper.Map<List<WineDto>>(AllWine);

        return MapperWine;
    }
    public bool AddWine(string name, decimal price, string img, string description)
    {
        var wine = new Wine
        {
            Name = name,
            Price = price,
            Img = img,
            Description = description
        };
        _context.wines.Add(wine);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteWine(int id) // ახალი მეთოდი წაშლისთვის
    {
        var Wine = _context.wines.FirstOrDefault(c => c.Id == id); // ვეძებთ ჩანაწერს
        if (Wine == null) return false; // თუ ჩანაწერი არ მოიძებნა, ვაბრუნებთ false-ს

        _context.wines.Remove(Wine); // ვშლით ჩანაწერს
        _context.SaveChanges(); // ვაფიქსირებთ ცვლილებებს მონაცემთა ბაზაში
        return true; // ვაბრუნებთ true-ს წარმატების შემთხვევაში
    }
}
