namespace BookingApp.Domain.Entities
{
    public class RoomCapacity
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
