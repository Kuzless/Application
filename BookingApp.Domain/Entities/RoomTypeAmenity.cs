namespace BookingApp.Domain.Entities
{
    public class RoomTypeAmenity
    {
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
