using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack.Migrations
{
    public partial class addDescColumnCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_socialPages_SocialPageId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_SocialPageId",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SocialPageId",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocialPageId1",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_SocialPageId1",
                table: "Authors",
                column: "SocialPageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_socialPages_SocialPageId1",
                table: "Authors",
                column: "SocialPageId1",
                principalTable: "socialPages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_socialPages_SocialPageId1",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_SocialPageId1",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SocialPageId1",
                table: "Authors");

            migrationBuilder.AlterColumn<int>(
                name: "SocialPageId",
                table: "Authors",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_SocialPageId",
                table: "Authors",
                column: "SocialPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_socialPages_SocialPageId",
                table: "Authors",
                column: "SocialPageId",
                principalTable: "socialPages",
                principalColumn: "Id");
        }
    }
}
