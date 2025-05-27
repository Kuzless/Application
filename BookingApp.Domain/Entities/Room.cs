namespace BookingApp.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int? Capacity { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
