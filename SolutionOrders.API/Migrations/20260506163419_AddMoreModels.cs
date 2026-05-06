using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionOrders.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetodyPlatnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodyPlatnosci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kwota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Metoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platnosci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serwisy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisUsterki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serwisy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWypozyczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZwrotu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetodyPlatnosci");

            migrationBuilder.DropTable(
                name: "Platnosci");

            migrationBuilder.DropTable(
                name: "Serwisy");

            migrationBuilder.DropTable(
                name: "Wypozyczenia");
        }
    }
}
