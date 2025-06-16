namespace BookingApp.Application.DTOs.Booking
{
    public class BookingInfoDTO
    {
        public BookingDTO Booking { get; set; }
        public RoomDTO Room { get; set; }
        public RoomTypeDTO RoomType { get; set; }
        public RoomCapacityDTO RoomCapacity { get; set; }
    }
}
