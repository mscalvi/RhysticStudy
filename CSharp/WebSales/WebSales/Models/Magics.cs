namespace WebSales.Models
{
    public class Magics
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Magics(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
