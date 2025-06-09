using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetUserBookingsInfo;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetUserBookingsInfo
{
    public class GetUserBookingsInfoQuery : IRequest<OperationResult<List<UserBookingInfoDTO>>>
    {
        public string UserId { get; set; }
    }
}
