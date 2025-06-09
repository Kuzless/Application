using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetAllBookingsInfo;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsInfoQuery : IRequest<OperationResult<List<BookingTypeInfoDTO>>> 
    {
        public string UserId { get; set; }
    }
}
