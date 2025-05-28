using AutoMapper;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.CQRS.Booking.Commands.DeleteBooking;
using BookingApp.Application.CQRS.Booking.Commands.UpdateBooking;
using BookingApp.Application.CQRS.Booking.Queries.GetAllBookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private protected readonly IMediator _mediator;
        private protected readonly IMapper _mapper;
        public BookingController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery());
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateNewBookingCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return ResponseErrorHandler.Handle(result.ErrorCode, result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return ResponseErrorHandler.Handle(result.ErrorCode, result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var command = new DeleteBookingCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return ResponseErrorHandler.Handle(result.ErrorCode, result.Message);
        }
    }
}
