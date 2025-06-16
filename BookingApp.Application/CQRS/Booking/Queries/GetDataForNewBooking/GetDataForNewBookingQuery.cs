using BookingApp.Application.DTOs;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking
{
    public class GetDataForNewBookingQuery : IRequest<OperationResult<List<RoomTypeWithCapacitiesDTO>>> { }
}
