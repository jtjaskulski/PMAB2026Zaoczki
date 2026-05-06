namespace SolutionOrders.API.Models
{
    public class Platnosc
    {
        public int Id { get; set; }
        public string Klient { get; set; } = "";
        public decimal Kwota { get; set; }
        public string Metoda { get; set; } = "";
        public string Status { get; set; } = "";
    }
}