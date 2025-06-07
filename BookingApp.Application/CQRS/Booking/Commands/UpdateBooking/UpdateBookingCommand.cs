using BookingApp.Application.DTOs;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<OperationResult<object>>
    {
        public int BookingId { get; set; }
        public int? RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public int? RoomCapacityId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
