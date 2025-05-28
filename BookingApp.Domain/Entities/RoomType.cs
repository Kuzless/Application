namespace BookingApp.Domain.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RoomTypeAmenity> RoomTypeAmenities { get; set; }
    }
}
