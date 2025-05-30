using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit
{
    public class GetBookingForEditQuery : IRequest<BookingWithAllRoomTypesDTO>
    {
        public int Id { get; set; }
    }
}
