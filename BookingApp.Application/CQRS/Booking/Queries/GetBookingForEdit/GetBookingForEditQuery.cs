using BookingApp.Application.DTOs.Booking;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit
{
    public class GetBookingForEditQuery : IRequest<BookingEditDTO>
    {
        public int Id { get; set; }
    }
}
