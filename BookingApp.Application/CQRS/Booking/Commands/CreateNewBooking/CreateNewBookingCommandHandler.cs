using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking
{
    public class CreateNewBookingCommandHandler : IRequestHandler<CreateNewBookingCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        public CreateNewBookingCommandHandler([FromKeyedServices("booking")] IResponseHandlerService responseHandler, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult> Handle(CreateNewBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var availableRooms = await _unitOfWork.RoomRepository.GetRoomsByTypeAndCapacity(request.RoomTypeId, request.RoomCapacityId);
                var freeRooms = new List<Room>();
                var startDate = DateOnly.Parse(request.StartDate);
                var endDate = DateOnly.Parse(request.EndDate);
                var startTime = TimeOnly.Parse(request.StartTime);
                
                if (request.EndTime == "24:00")
                {
                    request.EndTime = "00:00";
                    endDate = endDate.AddDays(1);
                    request.EndDate = endDate.ToString("yyyy-MM-dd");
                }
                var endTime = TimeOnly.Parse(request.EndTime);
                foreach (Room room in availableRooms)
                {
                    var isBooked = await _unitOfWork.BookingRepository.IsRoomBookedForTimePeriod(room.Id, startDate, endDate, startTime, endTime);
                    if (!isBooked)
                    {
                        freeRooms.Add(room);
                    }
                }
                if (freeRooms.IsNullOrEmpty())
                {
                    return _responseHandler.Handle(409);
                }
                request.RoomId = freeRooms[0].Id;
                _unitOfWork.BookingRepository.Add(_mapper.Map<Domain.Entities.Booking>(request));
                var changesNum = await _unitOfWork.SaveChangesAsync();
                if (changesNum > 0)
                {
                    return _responseHandler.Handle(200);
                }
                throw new Exception("An unexpected error occurred");
            } catch (Exception ex)
            {
                return _responseHandler.Handle(500, ex.Message);
            }
        }
    }
}
