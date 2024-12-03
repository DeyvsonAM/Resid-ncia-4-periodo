using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DTOs11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Sistema_SistemaId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_CustomAtributes_Custom_Atributes_CustomAtributeId",
                table: "Profile_CustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_CustomAtributes_Profiles_ProfileId",
                table: "Profile_CustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_CreateSistemaDTO_SistemaId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Profiles_Profiles_ProfileId",
                table: "User_Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Profiles_Users_UserId",
                table: "User_Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_CustomAtributes_Custom_Atributes_CustomAtributeId",
                table: "UserProfile_CustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_CustomAtributes_Profiles_BDProfileId",
                table: "UserProfile_CustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_CustomAtributes_User_Profiles_UserProfileId",
                table: "UserProfile_CustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_CustomAtributes_Users_UserId",
                table: "UserProfile_CustomAtributes");

            migrationBuilder.DropTable(
                name: "CreateSistemaDTO");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_SistemaId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfile_CustomAtributes",
                table: "UserProfile_CustomAtributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Profiles",
                table: "User_Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sistema",
                table: "Sistema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile_CustomAtributes",
                table: "Profile_CustomAtributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Custom_Atributes",
                table: "Custom_Atributes");

            migrationBuilder.DropColumn(
                name: "SistemaId",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "UserProfile_CustomAtributes",
                newName: "UserProfileCustomAtributes");

            migrationBuilder.RenameTable(
                name: "User_Profiles",
                newName: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "Sistema",
                newName: "Sistemas");

            migrationBuilder.RenameTable(
                name: "Profile_CustomAtributes",
                newName: "ProfileCustomAtributes");

            migrationBuilder.RenameTable(
                name: "Custom_Atributes",
                newName: "CustomAtributes");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_CustomAtributes_UserId",
                table: "UserProfileCustomAtributes",
                newName: "IX_UserProfileCustomAtributes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_CustomAtributes_CustomAtributeId",
                table: "UserProfileCustomAtributes",
                newName: "IX_UserProfileCustomAtributes_CustomAtributeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_CustomAtributes_BDProfileId",
                table: "UserProfileCustomAtributes",
                newName: "IX_UserProfileCustomAtributes_BDProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Profiles_UserId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Profiles_ProfileId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_CustomAtributes_CustomAtributeId",
                table: "ProfileCustomAtributes",
                newName: "IX_ProfileCustomAtributes_CustomAtributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileCustomAtributes",
                table: "UserProfileCustomAtributes",
                columns: new[] { "UserProfileId", "CustomAtributeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sistemas",
                table: "Sistemas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileCustomAtributes",
                table: "ProfileCustomAtributes",
                columns: new[] { "ProfileId", "CustomAtributeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomAtributes",
                table: "CustomAtributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Sistemas_SistemaId",
                table: "Permissions",
                column: "SistemaId",
                principalTable: "Sistemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileCustomAtributes_CustomAtributes_CustomAtributeId",
                table: "ProfileCustomAtributes",
                column: "CustomAtributeId",
                principalTable: "CustomAtributes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileCustomAtributes_Profiles_ProfileId",
                table: "ProfileCustomAtributes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCustomAtributes_CustomAtributes_CustomAtributeId",
                table: "UserProfileCustomAtributes",
                column: "CustomAtributeId",
                principalTable: "CustomAtributes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCustomAtributes_Profiles_BDProfileId",
                table: "UserProfileCustomAtributes",
                column: "BDProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCustomAtributes_UserProfiles_UserProfileId",
                table: "UserProfileCustomAtributes",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileCustomAtributes_Users_UserId",
                table: "UserProfileCustomAtributes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Profiles_ProfileId",
                table: "UserProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Sistemas_SistemaId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileCustomAtributes_CustomAtributes_CustomAtributeId",
                table: "ProfileCustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileCustomAtributes_Profiles_ProfileId",
                table: "ProfileCustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCustomAtributes_CustomAtributes_CustomAtributeId",
                table: "UserProfileCustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCustomAtributes_Profiles_BDProfileId",
                table: "UserProfileCustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCustomAtributes_UserProfiles_UserProfileId",
                table: "UserProfileCustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileCustomAtributes_Users_UserId",
                table: "UserProfileCustomAtributes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Profiles_ProfileId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileCustomAtributes",
                table: "UserProfileCustomAtributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sistemas",
                table: "Sistemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileCustomAtributes",
                table: "ProfileCustomAtributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomAtributes",
                table: "CustomAtributes");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "User_Profiles");

            migrationBuilder.RenameTable(
                name: "UserProfileCustomAtributes",
                newName: "UserProfile_CustomAtributes");

            migrationBuilder.RenameTable(
                name: "Sistemas",
                newName: "Sistema");

            migrationBuilder.RenameTable(
                name: "ProfileCustomAtributes",
                newName: "Profile_CustomAtributes");

            migrationBuilder.RenameTable(
                name: "CustomAtributes",
                newName: "Custom_Atributes");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_UserId",
                table: "User_Profiles",
                newName: "IX_User_Profiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_ProfileId",
                table: "User_Profiles",
                newName: "IX_User_Profiles_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileCustomAtributes_UserId",
                table: "UserProfile_CustomAtributes",
                newName: "IX_UserProfile_CustomAtributes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileCustomAtributes_CustomAtributeId",
                table: "UserProfile_CustomAtributes",
                newName: "IX_UserProfile_CustomAtributes_CustomAtributeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileCustomAtributes_BDProfileId",
                table: "UserProfile_CustomAtributes",
                newName: "IX_UserProfile_CustomAtributes_BDProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileCustomAtributes_CustomAtributeId",
                table: "Profile_CustomAtributes",
                newName: "IX_Profile_CustomAtributes_CustomAtributeId");

            migrationBuilder.AddColumn<Guid>(
                name: "SistemaId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Profiles",
                table: "User_Profiles",
                column: "UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfile_CustomAtributes",
                table: "UserProfile_CustomAtributes",
                columns: new[] { "UserProfileId", "CustomAtributeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sistema",
                table: "Sistema",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile_CustomAtributes",
                table: "Profile_CustomAtributes",
                columns: new[] { "ProfileId", "CustomAtributeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Custom_Atributes",
                table: "Custom_Atributes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CreateSistemaDTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioInserido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateSistemaDTO", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SistemaId",
                table: "Profiles",
                column: "SistemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Sistema_SistemaId",
                table: "Permissions",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_CustomAtributes_Custom_Atributes_CustomAtributeId",
                table: "Profile_CustomAtributes",
                column: "CustomAtributeId",
                principalTable: "Custom_Atributes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_CustomAtributes_Profiles_ProfileId",
                table: "Profile_CustomAtributes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_CreateSistemaDTO_SistemaId",
                table: "Profiles",
                column: "SistemaId",
                principalTable: "CreateSistemaDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profiles_Profiles_ProfileId",
                table: "User_Profiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profiles_Users_UserId",
                table: "User_Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_CustomAtributes_Custom_Atributes_CustomAtributeId",
                table: "UserProfile_CustomAtributes",
                column: "CustomAtributeId",
                principalTable: "Custom_Atributes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_CustomAtributes_Profiles_BDProfileId",
                table: "UserProfile_CustomAtributes",
                column: "BDProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_CustomAtributes_User_Profiles_UserProfileId",
                table: "UserProfile_CustomAtributes",
                column: "UserProfileId",
                principalTable: "User_Profiles",
                principalColumn: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_CustomAtributes_Users_UserId",
                table: "UserProfile_CustomAtributes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
