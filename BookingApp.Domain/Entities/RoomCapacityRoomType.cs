namespace BookingApp.Domain.Entities
{
    public class RoomCapacityRoomType
    {
        public int RoomCapacityId { get; set; }
        public RoomCapacity RoomCapacity { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
}
