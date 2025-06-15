using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking.GetUserBookingsInfo;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Booking.Queries.GetUserBookingsInfo
{
    public class GetUserBookingsInfoQueryHandler : IRequestHandler<GetUserBookingsInfoQuery, OperationResult<List<CoworkingWithBookingsDTO>>>
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
        public async Task<OperationResult<List<CoworkingWithBookingsDTO>>> Handle(GetUserBookingsInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var coworkings = await _unitOfWork.CoworkingRepository.GetCoworkingsWithBookingsByUserId(request.UserId);
                var result = coworkings.Select(c => new CoworkingWithBookingsDTO
                {
                    Coworking = _mapper.Map<CoworkingDTO>(c),
                    Bookings = c.Rooms.SelectMany(r => r.Bookings.Select(b => new UserBookingInfoDTO
                    {
                        Booking = _mapper.Map<BookingDTO>(b),
                        Room = _mapper.Map<RoomDTO>(r),
                        RoomType = _mapper.Map<RoomTypeDTO>(r.RoomType),
                        RoomCapacity = _mapper.Map<RoomCapacityDTO>(r.RoomCapacity)
                    })).ToList()
                }).ToList();
                return _responseHandler.Handle(200, data: result);
            } catch
            {
                return _responseHandler.Handle<List<CoworkingWithBookingsDTO>>(500, "An error occurred while retrieving data");
            }
        }
    }
}
