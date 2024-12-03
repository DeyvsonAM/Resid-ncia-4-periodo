﻿// <auto-generated />
using System;
using APISenac.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241130215849_DTOs")]
    partial class DTOs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APISenac.Models.BDProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SistemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioInserido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SistemaId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("APISenac.Models.CustomAtribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delimitador")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Requerimento")
                        .HasColumnType("tinyint");

                    b.Property<string>("TipoAtributo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioInserido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Custom_Atributes");
                });

            modelBuilder.Entity("APISenac.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SistemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioInserido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SistemaId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("APISenac.Models.ProfilePermission", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfilePermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfileId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("ProfilePermissions");
                });

            modelBuilder.Entity("APISenac.Models.Profile_CustomAtribute", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomAtributeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfileId", "CustomAtributeId");

                    b.HasIndex("CustomAtributeId");

                    b.ToTable("Profile_CustomAtributes");
                });

            modelBuilder.Entity("APISenac.Models.Sistema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioInserido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sistema");
                });

            modelBuilder.Entity("APISenac.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UsuarioInserido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APISenac.Models.UserProfile", b =>
                {
                    b.Property<Guid>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserProfileId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("User_Profiles");
                });

            modelBuilder.Entity("APISenac.Models.UserProfileCustomAtribute", b =>
                {
                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomAtributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BDProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserProfileId", "CustomAtributeId");

                    b.HasIndex("BDProfileId");

                    b.HasIndex("CustomAtributeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfile_CustomAtributes");
                });

            modelBuilder.Entity("APISenac.Models.BDProfile", b =>
                {
                    b.HasOne("APISenac.Models.Sistema", "Sistema")
                        .WithMany()
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sistema");
                });

            modelBuilder.Entity("APISenac.Models.Permission", b =>
                {
                    b.HasOne("APISenac.Models.Sistema", "Sistema")
                        .WithMany()
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sistema");
                });

            modelBuilder.Entity("APISenac.Models.ProfilePermission", b =>
                {
                    b.HasOne("APISenac.Models.Permission", "Permission")
                        .WithMany("ProfilePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APISenac.Models.BDProfile", "Profile")
                        .WithMany("ProfilePermissions")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("APISenac.Models.Profile_CustomAtribute", b =>
                {
                    b.HasOne("APISenac.Models.CustomAtribute", "CustomAtribute")
                        .WithMany("ProfileCustomAtributes")
                        .HasForeignKey("CustomAtributeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APISenac.Models.BDProfile", "Profile")
                        .WithMany("ProfileCustomAtributes")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CustomAtribute");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("APISenac.Models.UserProfile", b =>
                {
                    b.HasOne("APISenac.Models.BDProfile", "Profile")
                        .WithMany("UserProfiles")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APISenac.Models.User", "User")
                        .WithMany("UserProfiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APISenac.Models.UserProfileCustomAtribute", b =>
                {
                    b.HasOne("APISenac.Models.BDProfile", null)
                        .WithMany("UserProfileCustomAtributes")
                        .HasForeignKey("BDProfileId");

                    b.HasOne("APISenac.Models.CustomAtribute", "CustomAtribute")
                        .WithMany("UserProfileCustomAtributes")
                        .HasForeignKey("CustomAtributeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APISenac.Models.User", null)
                        .WithMany("UserProfileCustomAtributes")
                        .HasForeignKey("UserId");

                    b.HasOne("APISenac.Models.UserProfile", "UserProfile")
                        .WithMany("UserProfileCustomAtributes")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CustomAtribute");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("APISenac.Models.BDProfile", b =>
                {
                    b.Navigation("ProfileCustomAtributes");

                    b.Navigation("ProfilePermissions");

                    b.Navigation("UserProfileCustomAtributes");

                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("APISenac.Models.CustomAtribute", b =>
                {
                    b.Navigation("ProfileCustomAtributes");

                    b.Navigation("UserProfileCustomAtributes");
                });

            modelBuilder.Entity("APISenac.Models.Permission", b =>
                {
                    b.Navigation("ProfilePermissions");
                });

            modelBuilder.Entity("APISenac.Models.User", b =>
                {
                    b.Navigation("UserProfileCustomAtributes");

                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("APISenac.Models.UserProfile", b =>
                {
                    b.Navigation("UserProfileCustomAtributes");
                });
#pragma warning restore 612, 618
        }
    }
}
