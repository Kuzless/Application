using BookingApp.Application.DTOs;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetUserBookingsInfo
{
    public class GetUserBookingsInfoQuery : IRequest<OperationResult<List<GetUserBookingsInfoQueryDTO>>>
    {
        public string UserId { get; set; }
    }
}
