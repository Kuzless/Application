using AutoMapper;
using BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit
{
    public class GetBookingForEditQueryHandler : IRequestHandler<GetBookingForEditQuery, OperationResult<GetBookingForEditQueryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        public GetBookingForEditQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, [FromKeyedServices("booking")] IResponseHandlerService responseHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<OperationResult<GetBookingForEditQueryDTO>> Handle(GetBookingForEditQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithCapacity();
                var booking = await _unitOfWork.BookingRepository.GetBookingWithRoomDataById(request.Id);
                var responseData = _mapper.Map<GetBookingForEditQueryDTO>(booking);
                responseData.RoomTypes = _mapper.Map<List<RoomTypeWithCapacitiesDTO>>(data);
                return _responseHandler.Handle(200, data: responseData);
            }
            catch
            {
                return _responseHandler.Handle<GetBookingForEditQueryDTO>(500, "An error occurred while retrieving data");
            }
        }
    }
}
