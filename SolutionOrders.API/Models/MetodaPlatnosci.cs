namespace SolutionOrders.API.Models
{
    public class MetodaPlatnosci
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = "";
        public string Opis { get; set; } = "";
        public bool Aktywna { get; set; }
    }
}