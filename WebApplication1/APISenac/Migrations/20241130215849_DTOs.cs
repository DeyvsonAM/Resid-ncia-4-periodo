using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DTOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_CustomAtributes_Profiles_ProfileId",
                table: "UserProfile_CustomAtributes");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "UserProfile_CustomAtributes",
                newName: "BDProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_CustomAtributes_ProfileId",
                table: "UserProfile_CustomAtributes",
                newName: "IX_UserProfile_CustomAtributes_BDProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_CustomAtributes_Profiles_BDProfileId",
                table: "UserProfile_CustomAtributes",
                column: "BDProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_CustomAtributes_Profiles_BDProfileId",
                table: "UserProfile_CustomAtributes");

            migrationBuilder.RenameColumn(
                name: "BDProfileId",
                table: "UserProfile_CustomAtributes",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_CustomAtributes_BDProfileId",
                table: "UserProfile_CustomAtributes",
                newName: "IX_UserProfile_CustomAtributes_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_CustomAtributes_Profiles_ProfileId",
                table: "UserProfile_CustomAtributes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
