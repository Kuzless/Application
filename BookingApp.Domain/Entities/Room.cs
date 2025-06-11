namespace BookingApp.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int? RoomCapacityId { get; set; }
        public RoomCapacity? RoomCapacity { get; set; }
        public int CoworkingId { get; set; }
        public Coworking Coworking { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
