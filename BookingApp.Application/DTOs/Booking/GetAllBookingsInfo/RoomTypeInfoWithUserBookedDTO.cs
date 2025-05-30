namespace BookingApp.Application.DTOs.Booking.GetAllBookingsInfo
{
    public class RoomTypeInfoWithUserBookedDTO : RoomTypeWithCapacitiesNRoomsDTO
    {
        public List<AmenityDTO> Amenities { get; set; }
        public List<BookingWithRoomTypeDTO> BookingsWithRoomTypes { get; set; }
    }
}
