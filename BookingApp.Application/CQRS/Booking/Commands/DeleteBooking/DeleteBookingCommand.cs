﻿using BookingApp.Application.DTOs;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}
