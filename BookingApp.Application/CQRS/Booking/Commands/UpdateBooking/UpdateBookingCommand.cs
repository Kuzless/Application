using BookingApp.Application.DTOs;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
