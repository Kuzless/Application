using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetUserBookingsInfo;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Booking.Queries.GetUserBookingsInfo
{
    public class GetUserBookingsInfoQueryHandler : IRequestHandler<GetUserBookingsInfoQuery, OperationResult<List<UserBookingInfoDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;

        public GetUserBookingsInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, [FromKeyedServices("booking")] IResponseHandlerService responseHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult<List<UserBookingInfoDTO>>> Handle(GetUserBookingsInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bookings = await _unitOfWork.BookingRepository.GetBookingsWithRoomDataByUserId(request.UserId);
                var result = _mapper.Map<List<UserBookingInfoDTO>>(bookings);
                return _responseHandler.Handle(200, data: result);
            } catch
            {
                return _responseHandler.Handle<List<UserBookingInfoDTO>>(500, "An error occurred while retrieving data");
            }
        }
    }
}
