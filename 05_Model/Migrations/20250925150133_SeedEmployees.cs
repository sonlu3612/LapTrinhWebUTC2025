using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _05_Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FullName", "Gender", "Phone", "Salary", "Status" },
                values: new object[,]
                {
                    { 1, "vana@example.com", "Nguyen Van A", "Male", "0901234567", 1200.50m, "Active" },
                    { 2, "thib@example.com", "Tran Thi B", "Female", "0912345678", 1500.00m, "Inactive" },
                    { 3, "vanc@example.com", "Le Van C", "Male", "0987654321", 1800.75m, "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
