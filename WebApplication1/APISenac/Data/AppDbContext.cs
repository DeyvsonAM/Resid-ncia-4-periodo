using Microsoft.EntityFrameworkCore;
using APISenac.Models;

namespace APISenac.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definindo os DbSets para suas entidades
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserProfile> User_Profiles { get; set; }
        
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProfilePermission> ProfilePermissions { get; set; }
        public DbSet<CustomAtribute> Custom_Atributes { get; set; }
        public DbSet<Profile_CustomAtribute> Profile_CustomAtributes { get; set; }
        public DbSet<UserProfileCustomAtribute> UserProfile_CustomAtributes { get; set; }

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
    modelBuilder.Entity<UserProfile>()
        .HasKey(up => new { up.UserProfileId });

    modelBuilder.Entity<UserProfile>()
        .HasOne(up => up.User)
        .WithMany(u => u.UserProfiles)
        .HasForeignKey(up => up.UserId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<UserProfile>()
        .HasOne(up => up.Profile)
        .WithMany(p => p.UserProfiles)
        .HasForeignKey(up => up.ProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configuração de Profile_Permission (muitas para muitas entre Profile e Permission)
    modelBuilder.Entity<ProfilePermission>()
        .HasKey(pp => new { pp.ProfileId, pp.PermissionId });

    modelBuilder.Entity<ProfilePermission>()
        .HasOne(pp => pp.Profile)
        .WithMany(p => p.ProfilePermissions)
        .HasForeignKey(pp => pp.ProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<ProfilePermission>()
        .HasOne(pp => pp.Permission)
        .WithMany(p => p.ProfilePermissions)
        .HasForeignKey(pp => pp.PermissionId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configuração de Profile_CustomAtribute (muitas para muitas entre Profile e Custom_Atribute)
    modelBuilder.Entity<Profile_CustomAtribute>()
        .HasKey(pc => new { pc.ProfileId, pc.CustomAtributeId });

    modelBuilder.Entity<Profile_CustomAtribute>()
        .HasOne(pc => pc.Profile)
        .WithMany(p => p.ProfileCustomAtributes)
        .HasForeignKey(pc => pc.ProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Profile_CustomAtribute>()
        .HasOne(pc => pc.CustomAtribute)
        .WithMany(ca => ca.ProfileCustomAtributes)
        .HasForeignKey(pc => pc.CustomAtributeId)
        .OnDelete(DeleteBehavior.NoAction);

    // Configuração de UserProfile_CustomAtribute (chave composta entre UserProfile e CustomAtribute)
    modelBuilder.Entity<UserProfileCustomAtribute>()
        .HasKey(uca => new { uca.UserProfileId, uca.CustomAtributeId });

    // Relacionamento com User_Profile
    modelBuilder.Entity<UserProfileCustomAtribute>()
        .HasOne(uca => uca.UserProfile)
        .WithMany(up => up.UserProfileCustomAtributes)
        .HasForeignKey(uca => uca.UserProfileId)
        .OnDelete(DeleteBehavior.NoAction);

    // Relacionamento com Custom_Atribute
    modelBuilder.Entity<UserProfileCustomAtribute>()
        .HasOne(uca => uca.CustomAtribute)
        .WithMany(ca => ca.UserProfileCustomAtributes)
        .HasForeignKey(uca => uca.CustomAtributeId)
        .OnDelete(DeleteBehavior.NoAction);}}}