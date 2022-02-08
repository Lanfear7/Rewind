using Microsoft.EntityFrameworkCore.Migrations;

namespace rolesDemoSSD.Migrations
{
    public partial class seededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produces",
                columns: new[] { "ProduceID", "Description" },
                values: new object[] { 1, "Oranges" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "SupplierName" },
                values: new object[] { 1, "Kin's Market" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "SupplierName" },
                values: new object[] { 2, "Fresh Street Market" });

            migrationBuilder.InsertData(
                table: "ProduceSuppliers",
                columns: new[] { "ProduceID", "SupplierID", "Qty" },
                values: new object[] { 1, 1, 25 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProduceSuppliers",
                keyColumns: new[] { "ProduceID", "SupplierID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produces",
                keyColumn: "ProduceID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 1);
        }
    }
}
