using Microsoft.EntityFrameworkCore;
using APISenac.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definindo os DbSets para suas entidades
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User_Profile> User_Profiles { get; set; }
        
        public DbSet<Permition> Permitions { get; set; }
        public DbSet<Profile_Permition> Profile_Permitions { get; set; }
        public DbSet<Custom_Atribute> Custom_Atributes { get; set; }
        public DbSet<Profile_CustomAtribute> Profile_CustomAtributes { get; set; }
        public DbSet<UserProfile_CustomAtribute> UserProfile_CustomAtributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Configuração para User
    modelBuilder.Entity<User>()
        .Property(u => u.Nome)
        .IsRequired()
        .HasMaxLength(100);

    modelBuilder.Entity<User>()
        .Property(u => u.Email)
        .IsRequired()
        .HasMaxLength(100);

    // Configuração de User_Profile
    modelBuilder.Entity<User_Profile>()
        .HasKey(up => new { up.UserProfileId });

    modelBuilder.Entity<User_Profile>()
        .HasOne(up => up.User)
        .WithMany(u => u.User_Profiles)
        .HasForeignKey(up => up.UserId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<User_Profile>()
        .HasOne(up => up.Profile)
        .WithMany(p => p.User_Profiles)
        .HasForeignKey(up => up.ProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configuração de Profile_Permition (muitas para muitas entre Profile e Permition)
    modelBuilder.Entity<Profile_Permition>()
        .HasKey(pp => new { pp.ProfileId, pp.PermitionId });

    modelBuilder.Entity<Profile_Permition>()
        .HasOne(pp => pp.Profile)
        .WithMany(p => p.Profile_Permitions)
        .HasForeignKey(pp => pp.ProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Profile_Permition>()
        .HasOne(pp => pp.Permition)
        .WithMany(p => p.Profile_Permitions)
        .HasForeignKey(pp => pp.PermitionId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configuração de Profile_CustomAtribute (muitas para muitas entre Profile e Custom_Atribute)
    modelBuilder.Entity<Profile_CustomAtribute>()
        .HasKey(pc => new { pc.ProfileId, pc.CustomAtributeId });

    modelBuilder.Entity<Profile_CustomAtribute>()
        .HasOne(pc => pc.Profile)
        .WithMany(p => p.Profile_CustomAtributes)
        .HasForeignKey(pc => pc.ProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Profile_CustomAtribute>()
        .HasOne(pc => pc.CustomAtribute)
        .WithMany(ca => ca.Profile_CustomAtributes)
        .HasForeignKey(pc => pc.CustomAtributeId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configuração de UserProfile_CustomAtribute (chave composta entre UserProfile e CustomAtribute)
    modelBuilder.Entity<UserProfile_CustomAtribute>()
        .HasKey(uca => new { uca.UserProfileId, uca.CustomAtributeId });

    // Relacionamento com User_Profile
    modelBuilder.Entity<UserProfile_CustomAtribute>()
        .HasOne(uca => uca.User_Profile)
        .WithMany(up => up.UserProfile_CustomAtributes)
        .HasForeignKey(uca => uca.UserProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    // Relacionamento com Custom_Atribute
    modelBuilder.Entity<UserProfile_CustomAtribute>()
        .HasOne(uca => uca.CustomAtribute)
        .WithMany(ca => ca.UserProfile_CustomAtributes)
        .HasForeignKey(uca => uca.CustomAtributeId)
        .OnDelete(DeleteBehavior.NoAction);}}}