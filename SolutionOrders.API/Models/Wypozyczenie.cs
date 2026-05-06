namespace SolutionOrders.API.Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }
        public string Klient { get; set; } = "";
        public string Rower { get; set; } = "";
        public DateTime DataWypozyczenia { get; set; }
        public DateTime? DataZwrotu { get; set; }
        public string Status { get; set; } = "";
    }
}