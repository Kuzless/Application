using BookingApp.Application.DTOs.Booking;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IRequest<List<BookingDTO>> { }
}
