using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Migrations
{
    public partial class DataSeedForProducts_And_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cars" },
                    { 2, "Planes" },
                    { 3, "Trucks" },
                    { 4, "Boats" },
                    { 5, "Rockets" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price", "ProductCategoryId" },
                values: new object[,]
                {
                    { 1, "Ferari", 3000m, 1 },
                    { 2, "Benz", 4000m, 1 },
                    { 3, "AirBus", 5000m, 2 },
                    { 4, "Jet", 6000m, 2 },
                    { 5, "Hummer", 7000m, 3 },
                    { 6, "Container", 8000m, 3 },
                    { 7, "Spider", 9000m, 4 },
                    { 8, "Jet Boat", 10000m, 4 },
                    { 9, "RocketA", 11000m, 5 },
                    { 10, "RocketB", 12000m, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
