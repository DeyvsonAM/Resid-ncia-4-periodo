using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DTOs10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Sistema_SistemaId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfilePermissionId",
                table: "ProfilePermissions",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ProfilePermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCriacao",
                table: "ProfilePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ProfilePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInserido",
                table: "ProfilePermissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CreateSistemaDTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateSistemaDTO", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_CreateSistemaDTO_SistemaId",
                table: "Profiles",
                column: "SistemaId",
                principalTable: "CreateSistemaDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_CreateSistemaDTO_SistemaId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "CreateSistemaDTO");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProfilePermissions");

            migrationBuilder.DropColumn(
                name: "DataDeCriacao",
                table: "ProfilePermissions");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ProfilePermissions");

            migrationBuilder.DropColumn(
                name: "UsuarioInserido",
                table: "ProfilePermissions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProfilePermissions",
                newName: "ProfilePermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Sistema_SistemaId",
                table: "Profiles",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
