using BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking;

namespace BookingApp.Application.DTOs.Booking.GetBookingForEdit
{
    public class GetBookingForEditQueryDTO
    {
        public BookingDTO Booking { get; set; }
        public RoomTypeDTO RoomType { get; set; }
        public RoomCapacityDTO RoomCapacity { get; set; }
        public List<RoomTypeWithCapacitiesDTO> RoomTypes { get; set; }
    }
}
