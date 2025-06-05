using BookingApp.API.Interfaces;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.CQRS.Booking.Commands.DeleteBooking;
using BookingApp.Application.CQRS.Booking.Commands.UpdateBooking;
using BookingApp.Application.CQRS.Booking.Queries.GetAllBookings;
using BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit;
using BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IApiResponseHandler _apiResponseHandler;
        public BookingController(IMediator mediator, IApiResponseHandler apiResponseHandler)
        {
            _mediator = mediator;
            _apiResponseHandler = apiResponseHandler;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBookingsInfo(string userId)
        {
            var bookings = await _mediator.Send(new GetAllBookingsInfoQuery() { UserId = userId });
            return _apiResponseHandler.Handle(bookings);
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateNewBookingCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return _apiResponseHandler.Handle(result.ErrorCode, result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return _apiResponseHandler.Handle(result.ErrorCode, result.Message);
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
            return _apiResponseHandler.Handle(result.ErrorCode, result.Message);
        }

        [HttpGet("add")]
        public async Task<IActionResult> GetDataForNewBooking()
        {
            var data = await _mediator.Send(new GetDataForNewBookingQuery());
            return _apiResponseHandler.Handle(data);
        }
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> GetBookingForEdit(int id)
        {
            var data = await _mediator.Send(new GetBookingForEditQuery { Id = id });
            return _apiResponseHandler.Handle(data);
        }
    }
}
