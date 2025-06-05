using AutoMapper;
using BookingApp.Application.DTOs.Booking.GetAllBookingsInfo;
using BookingApp.Domain.Interfaces;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsInfoQueryHandler : IRequestHandler<GetAllBookingsInfoQuery, List<BookingTypeInfoDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllBookingsInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<BookingTypeInfoDTO>> Handle(GetAllBookingsInfoQuery request, CancellationToken cancellationToken)
        {
            var typeInfo = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithFullInfo();
            var userBookings = await _unitOfWork.BookingRepository.GetBookingsWithRoomByUserId(request.UserId);
            // mapping full data about 'booking type'
            var fullInfo = _mapper.Map<List<BookingTypeInfoDTO>>(typeInfo);
            // adding user bookings to each type (to show on which types did user book)
            foreach (var dto in fullInfo)
            {
                dto.BookingInfos = new List<BookingInfoDTO>();
                foreach (var booking in userBookings)
                {
                    if (dto.RoomType.Id == booking.Room.RoomTypeId)
                    {
                        dto.BookingInfos.Add(_mapper.Map<BookingInfoDTO>(booking));
                    }
                }
            }
            return fullInfo;
        }
    }
}
