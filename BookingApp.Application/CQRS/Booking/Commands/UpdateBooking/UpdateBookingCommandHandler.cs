using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, OperationResult<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        public UpdateBookingCommandHandler([FromKeyedServices("booking")] IResponseHandlerService responseHandler, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult<object>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                /*
                var bookings = await _unitOfWork.BookingRepository.GetRoomBookingsForTimePeriod(request.RoomId, request.StartDate, request.EndDate);
                switch (bookings.Count)
                {
                    case 0:
                        return _responseHandler.Handle(404);
                    case 1:
                        if (bookings.First().Id != request.Id)
                        {
                            return _responseHandler.Handle(409);
                        }
                        _unitOfWork.BookingRepository.Update(_mapper.Map<Domain.Entities.Booking>(request));
                        var changesNum = await _unitOfWork.SaveChangesAsync();
                        if (changesNum > 0)
                        {
                            return _responseHandler.Handle(200);
                        }
                        break;
                    default:
                        return _responseHandler.Handle(409);
                }*/
                throw new Exception("An unexpected error occurred");
            }
            catch (Exception ex)
            {
                return _responseHandler.Handle<object>(500, ex.Message);
            }
        }
    }
}
