using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolutionOrders.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klienci",
                columns: new[] { "Id", "Imie", "Nazwisko", "Telefon" },
                values: new object[] { 1, "Jan", "Kowalski", "123456789" });

            migrationBuilder.InsertData(
                table: "Rowery",
                columns: new[] { "Id", "Cena", "Nazwa", "Status", "Typ" },
                values: new object[,]
                {
                    { 1, 15m, "Trek Marlin 5", "Dostępny", "MTB" },
                    { 2, 12m, "Kross Evado", "Wypożyczony", "Trekking" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rowery",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rowery",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
