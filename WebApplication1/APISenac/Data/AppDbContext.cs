using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APISenac.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        // Construtor que recebe DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definindo os DbSets
        public DbSet<Sistema> Sistemas { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permitions> Permitionss { get; set; } 
        public DbSet<Custom_Atribute> Custom_Atributes { get; set; }
        public DbSet<User_Profile> User_Profiles { get; set; }
        public DbSet<UserProfile_CustomAtribute> UserProfile_CustomAtributes { get; set; }
        public DbSet<Profile_Permition> Profile_Permitions { get; set; }
        public DbSet<Profile_CustomAtribute> Profile_CustomAtributes { get; set; }
       }
       

    }

