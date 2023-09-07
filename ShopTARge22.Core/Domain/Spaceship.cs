namespace ShopTARge22.Core.Domain
{
    public class Spaceship
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public String Type { get; set; }
        public DateTime? BuiltDate { get; set; }
        public int Passengers { get; set; }

    }
}
