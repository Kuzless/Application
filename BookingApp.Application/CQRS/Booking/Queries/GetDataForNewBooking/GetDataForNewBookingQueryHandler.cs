using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetDataForNewBooking;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking
{
    public class GetDataForNewBookingQueryHandler : IRequestHandler<GetDataForNewBookingQuery, OperationResult<List<NewBookingStructureDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        public GetDataForNewBookingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, [FromKeyedServices("booking")] IResponseHandlerService responseHandler)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult<List<NewBookingStructureDTO>>> Handle(GetDataForNewBookingQuery request, CancellationToken cancellationToken)
        {
            try 
            {
                var data = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithCapacity();
                var result = _mapper.Map<List<NewBookingStructureDTO>>(data);
                return _responseHandler.Handle(200, data: result);
            }
            catch
            {
                return _responseHandler.Handle<List<NewBookingStructureDTO>>(500, "An error occurred while retrieving data");
            }
        }
    }
}
