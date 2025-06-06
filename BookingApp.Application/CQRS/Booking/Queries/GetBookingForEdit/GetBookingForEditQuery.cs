using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit
{
    public class GetBookingForEditQuery : IRequest<OperationResult<BookingWithAllRoomTypesDTO>>
    {
        public int Id { get; set; }
    }
}
