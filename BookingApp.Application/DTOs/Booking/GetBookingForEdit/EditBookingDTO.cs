using BookingApp.Application.DTOs.Booking.GetDataForNewBooking;

namespace BookingApp.Application.DTOs.Booking.GetBookingForEdit
{
    public class EditBookingDTO
    {
        public BookingDTO Booking { get; set; }
        public RoomTypeDTO RoomType { get; set; }
        public RoomCapacityDTO RoomCapacity { get; set; }
        public List<NewBookingStructureDTO> RoomTypes { get; set; }
    }
}
