using BookingApp.Application.DTOs.Booking.GetAllBookingsInfo;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsInfoQuery : IRequest<List<RoomTypeInfoDTO>> 
    {
        public string Email { get; set; }
    }
}
