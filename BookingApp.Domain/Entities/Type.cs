namespace BookingApp.Domain.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Room> Rooms { get; set; }
        public List<TypeAmenity> TypeAmenities { get; set; }
    }
}
