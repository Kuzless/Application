using BookingApp.API.Interfaces;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.CQRS.Booking.Commands.DeleteBooking;
using BookingApp.Application.CQRS.Booking.Commands.UpdateBooking;
using BookingApp.Application.CQRS.Booking.Queries.GetAllBookings;
using BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit;
using BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking;
using BookingApp.Application.CQRS.Booking.Queries.GetUserBookingsInfo;
using BookingApp.Domain.Entities;
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

        // retrieves booking types with all additional info
        // userid is needed to retrieve info about bookings that user booked
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBookingsInfo(string userId)
        {
            var bookings = await _mediator.Send(new GetAllBookingsInfoQuery() { UserId = userId });
            return _apiResponseHandler.Handle(bookings);
        }

        // retrieves bookings info made by user
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBookingsByUserId(string userId)
        {
            var bookings = await _mediator.Send(new GetUserBookingsInfoQuery() { UserId = userId });
            return _apiResponseHandler.Handle(bookings);
        }

        // creates new booking
        [HttpPost("add")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateNewBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return _apiResponseHandler.Handle(result);
        }

        // updates existing booking
        [HttpPut("edit")]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return _apiResponseHandler.Handle(result);
        }

        // deletes existing booking
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _mediator.Send(new DeleteBookingCommand { Id = id });
            return _apiResponseHandler.Handle(result);
        }

        // retrieves structure for new booking form, such as types, capacities
        [HttpGet("add")]
        public async Task<IActionResult> GetDataForNewBooking()
        {
            var data = await _mediator.Send(new GetDataForNewBookingQuery());
            return _apiResponseHandler.Handle(data);
        }

        // retrieves structure for edit booking form, such as types, capacities
        // also retrieves booking that will be edited
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> GetBookingForEdit(int id)
        {
            var data = await _mediator.Send(new GetBookingForEditQuery { Id = id });
            return _apiResponseHandler.Handle(data);
        }
    }
}
