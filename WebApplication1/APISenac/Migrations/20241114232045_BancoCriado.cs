using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class BancoCriado : Migration
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
                name: "Sistema",
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
                    table.PrimaryKey("PK_Sistema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                name: "Permitions",
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
                    table.PrimaryKey("PK_Permitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permitions_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
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
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile_CustomAtributes",
                columns: table => new
                {
                    CustomAtributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_CustomAtributes", x => new { x.ProfileId, x.CustomAtributeId });
                    table.ForeignKey(
                        name: "FK_Profile_CustomAtributes_Custom_Atributes_CustomAtributeId",
                        column: x => x.CustomAtributeId,
                        principalTable: "Custom_Atributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profile_CustomAtributes_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Profile_Permitions",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfilePermitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_Permitions", x => new { x.ProfileId, x.PermitionId });
                    table.ForeignKey(
                        name: "FK_Profile_Permitions_Permitions_PermitionId",
                        column: x => x.PermitionId,
                        principalTable: "Permitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profile_Permitions_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User_Profiles",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Profiles", x => x.UserProfileId);
                    table.ForeignKey(
                        name: "FK_User_Profiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProfile_CustomAtributes",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomAtributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile_CustomAtributes", x => new { x.UserProfileId, x.CustomAtributeId });
                    table.ForeignKey(
                        name: "FK_UserProfile_CustomAtributes_Custom_Atributes_CustomAtributeId",
                        column: x => x.CustomAtributeId,
                        principalTable: "Custom_Atributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfile_CustomAtributes_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfile_CustomAtributes_User_Profiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "User_Profiles",
                        principalColumn: "UserProfileId");
                    table.ForeignKey(
                        name: "FK_UserProfile_CustomAtributes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permitions_SistemaId",
                table: "Permitions",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_CustomAtributes_CustomAtributeId",
                table: "Profile_CustomAtributes",
                column: "CustomAtributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Permitions_PermitionId",
                table: "Profile_Permitions",
                column: "PermitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SistemaId",
                table: "Profiles",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Profiles_ProfileId",
                table: "User_Profiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Profiles_UserId",
                table: "User_Profiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CustomAtributes_CustomAtributeId",
                table: "UserProfile_CustomAtributes",
                column: "CustomAtributeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CustomAtributes_ProfileId",
                table: "UserProfile_CustomAtributes",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CustomAtributes_UserId",
                table: "UserProfile_CustomAtributes",
                column: "UserId");
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
                name: "Permitions");

            migrationBuilder.DropTable(
                name: "Custom_Atributes");

            migrationBuilder.DropTable(
                name: "User_Profiles");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sistema");
        }
    }
}
