using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Application.Interfaces.Booking;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking
{
    public class CreateNewBookingCommandHandler : IRequestHandler<CreateNewBookingCommand, OperationResult<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        private readonly IBookingCommandService _bookingCommandService;
        public CreateNewBookingCommandHandler([FromKeyedServices("booking")] IResponseHandlerService responseHandler, IUnitOfWork unitOfWork, IMapper mapper, IBookingCommandService bookingCommandService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
            _bookingCommandService = bookingCommandService;
        }
        public async Task<OperationResult<object>> Handle(CreateNewBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var room = await _bookingCommandService.FindAvailableRoom(request.RoomTypeId, request.CoworkingId, request.RoomCapacityId, request.StartDate, request.EndDate, request.StartTime, request.EndTime);
                if (room == null)
                {
                    return _responseHandler.Handle<object>(409);
                }
                request.RoomId = room.Id;
                _unitOfWork.BookingRepository.Add(_mapper.Map<Domain.Entities.Booking>(request));
                var changesNum = await _unitOfWork.SaveChangesAsync();
                if (changesNum > 0)
                {
                    return _responseHandler.Handle<object>(200);
                }
                throw new Exception("An unexpected error occurred");
            } catch (Exception ex)
            {
                return _responseHandler.Handle<object>(500, ex.Message);
            }
        }
    }
}
