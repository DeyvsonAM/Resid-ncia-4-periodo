using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities.sistemas;

namespace WebApplication1.data;

public class AppDbContex : DbContext
{
    public DbSet<Sistema> Sistemas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}