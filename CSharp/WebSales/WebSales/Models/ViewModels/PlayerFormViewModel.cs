namespace WebSales.Models.ViewModels
{
    public class PlayerFormViewModel
    {
        public Players Player { get; set; }
        public ICollection<Tournaments> Tournaments { get; set; }

    }
}
