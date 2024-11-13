using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.sistemas;
using APISenac.Models.Profile;

namespace WebApplication1.Data;

public class AppDbContex : DbContext
{
    public DbSet<Sistema> Sistemas { get; set; }
    public DbSet<Profile> Profiles {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}