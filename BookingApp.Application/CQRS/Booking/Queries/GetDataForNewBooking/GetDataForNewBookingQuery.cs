﻿using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking
{
    public class GetDataForNewBookingQuery : IRequest<List<RoomTypeWithCapacitiesDTO>> { }
}
