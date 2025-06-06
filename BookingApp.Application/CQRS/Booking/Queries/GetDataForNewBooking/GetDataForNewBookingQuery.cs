﻿using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetDataForNewBooking;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking
{
    public class GetDataForNewBookingQuery : IRequest<OperationResult<List<NewBookingStructureDTO>>> { }
}
