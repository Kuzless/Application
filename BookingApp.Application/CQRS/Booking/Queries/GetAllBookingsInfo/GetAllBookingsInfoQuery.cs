using BookingApp.Application.DTOs.Booking;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsInfoQuery : IRequest<List<RoomTypeInfoWithUserBookedDTO>> 
    {
        public string Email { get; set; }
    }
}
