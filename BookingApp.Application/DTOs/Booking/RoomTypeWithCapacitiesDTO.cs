using BookingApp.Application.DTOs;

namespace BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking
{
    public class RoomTypeWithCapacitiesDTO
    {
        public RoomTypeDTO RoomType { get; set; }
        public List<RoomCapacityDTO> RoomCapacities { get; set; }
    }
}
