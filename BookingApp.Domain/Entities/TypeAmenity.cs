namespace BookingApp.Domain.Entities
{
    public class TypeAmenity
    {
        public int Name { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
