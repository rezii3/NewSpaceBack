using Microsoft.EntityFrameworkCore;
using NewSpace.Model;
namespace NewSpace.Data;

public class DataContxt:DbContext
{
    public DbSet<Coctaile> coctailes { get; set;}
    public DbSet<Food> foods { get; set;}
    public DbSet<Tea_Coffe> tea_coffes { get; set;}
    public DbSet<Wine> wines { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NewSpacee;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}