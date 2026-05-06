using Microsoft.EntityFrameworkCore;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rower> Rowery { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<TypRoweru> TypyRowerow { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }
        public DbSet<Serwis> Serwisy { get; set; }
        public DbSet<Platnosc> Platnosci { get; set; }
        public DbSet<MetodaPlatnosci> MetodyPlatnosci { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rower>().HasData(
                new Rower
                {
                    Id = 1,
                    Nazwa = "Trek Marlin 5",
                    Typ = "MTB",
                    Cena = 15,
                    Status = "Dostępny"
                },
                new Rower
                {
                    Id = 2,
                    Nazwa = "Kross Evado",
                    Typ = "Trekking",
                    Cena = 12,
                    Status = "Wypożyczony"
                }
            );

            modelBuilder.Entity<Klient>().HasData(
                new Klient
                {
                    Id = 1,
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    Telefon = "123456789"
                }
            );
        }
    }
}