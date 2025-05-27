namespace BookingApp.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TypeAmenity> TypeAmenities { get; set; }
    }
}
