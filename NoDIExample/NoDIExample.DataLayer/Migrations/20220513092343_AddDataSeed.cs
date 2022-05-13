using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoDIExample.DataLayer.Migrations
{
    public partial class AddDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Products",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsFeatured", "Name", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("320cb512-92b5-4d49-8801-885873437055"), "This is product 1", true, "Product 1", 5000m },
                    { new Guid("58ce934b-f92b-4504-97bf-988cf16c101c"), "This is product 3", false, "Product 3", 2500m },
                    { new Guid("5d277e67-63ea-41f8-9e00-441b90245977"), "This is product 4", true, "Product 4", 7500m },
                    { new Guid("dd5924fe-8707-4e4a-84c6-b827b98463b0"), "This is product 2", true, "Product 2", 3000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("320cb512-92b5-4d49-8801-885873437055"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58ce934b-f92b-4504-97bf-988cf16c101c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d277e67-63ea-41f8-9e00-441b90245977"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd5924fe-8707-4e4a-84c6-b827b98463b0"));

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
