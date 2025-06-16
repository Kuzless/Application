using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking;

namespace BookingApp.Application.CQRS.Booking.Queries.GetUserBookingsInfo
{
    public class GetUserBookingsInfoQueryDTO
    {
        public CoworkingDTO Coworking { get; set; }
        public List<BookingInfoDTO> Bookings { get; set; }
    }
}
