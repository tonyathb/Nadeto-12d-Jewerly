using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jewerly.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Articuls");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Articuls",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Articuls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Articuls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shoppings_ArticulId",
                table: "Shoppings",
                column: "ArticulId");

            migrationBuilder.CreateIndex(
                name: "IX_Articuls_CategoriesId",
                table: "Articuls",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Articuls_TypeId",
                table: "Articuls",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articuls_Categories_CategoriesId",
                table: "Articuls",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articuls_Types_TypeId",
                table: "Articuls",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoppings_Articuls_ArticulId",
                table: "Shoppings",
                column: "ArticulId",
                principalTable: "Articuls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articuls_Categories_CategoriesId",
                table: "Articuls");

            migrationBuilder.DropForeignKey(
                name: "FK_Articuls_Types_TypeId",
                table: "Articuls");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoppings_Articuls_ArticulId",
                table: "Shoppings");

            migrationBuilder.DropIndex(
                name: "IX_Shoppings_ArticulId",
                table: "Shoppings");

            migrationBuilder.DropIndex(
                name: "IX_Articuls_CategoriesId",
                table: "Articuls");

            migrationBuilder.DropIndex(
                name: "IX_Articuls_TypeId",
                table: "Articuls");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Articuls");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Articuls");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "categoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Articuls",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Articuls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
