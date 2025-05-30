namespace BookingApp.Application.DTOs.Booking.GetAllBookingsInfo
{
    public class RoomTypeInfoDTO
    {
        public RoomTypeDTO RoomType { get; set; }
        public List<RoomCapacityInfoDTO> RoomCapacities { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
        public List<BookingInfoDTO> BookingInfos { get; set; }
    }
}
