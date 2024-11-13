using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class TodasAsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Custom_Atributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAtributo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requerimento = table.Column<byte>(type: "tinyint", nullable: false),
                    Delimitador = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custom_Atributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permitionss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SistemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permitionss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permitionss_Sistemas_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile_CustomAtributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Custom_AtributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_CustomAtributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_CustomAtributes_Custom_Atributes_Custom_AtributeId",
                        column: x => x.Custom_AtributeId,
                        principalTable: "Custom_Atributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_CustomAtributes_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile_Permitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermitionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_Permitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Permitions_Permitionss_PermitionsId",
                        column: x => x.PermitionsId,
                        principalTable: "Permitionss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_Permitions_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Profiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile_CustomAtributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Custom_AtributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile_CustomAtributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_CustomAtributes_Custom_Atributes_Custom_AtributeId",
                        column: x => x.Custom_AtributeId,
                        principalTable: "Custom_Atributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfile_CustomAtributes_User_Profiles_User_ProfileId",
                        column: x => x.User_ProfileId,
                        principalTable: "User_Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permitionss_SistemaId",
                table: "Permitionss",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_CustomAtributes_Custom_AtributeId",
                table: "Profile_CustomAtributes",
                column: "Custom_AtributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_CustomAtributes_ProfileId",
                table: "Profile_CustomAtributes",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Permitions_PermitionsId",
                table: "Profile_Permitions",
                column: "PermitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Permitions_ProfileId",
                table: "Profile_Permitions",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Profiles_ProfileId",
                table: "User_Profiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Profiles_UserId",
                table: "User_Profiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CustomAtributes_Custom_AtributeId",
                table: "UserProfile_CustomAtributes",
                column: "Custom_AtributeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CustomAtributes_User_ProfileId",
                table: "UserProfile_CustomAtributes",
                column: "User_ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profile_CustomAtributes");

            migrationBuilder.DropTable(
                name: "Profile_Permitions");

            migrationBuilder.DropTable(
                name: "UserProfile_CustomAtributes");

            migrationBuilder.DropTable(
                name: "Permitionss");

            migrationBuilder.DropTable(
                name: "Custom_Atributes");

            migrationBuilder.DropTable(
                name: "User_Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
