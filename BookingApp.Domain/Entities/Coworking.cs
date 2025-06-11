namespace BookingApp.Domain.Entities
{
    public class Coworking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
