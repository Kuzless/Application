using AutoMapper;
using BookingApp.Application.DTOs.Booking.GetAllBookingsInfo;
using BookingApp.Domain.Interfaces;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsInfoQueryHandler : IRequestHandler<GetAllBookingsInfoQuery, List<RoomTypeInfoWithUserBookedDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllBookingsInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<RoomTypeInfoWithUserBookedDTO>> Handle(GetAllBookingsInfoQuery request, CancellationToken cancellationToken)
        {
            var typeInfo = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithFullInfo();
            var userBookings = await _unitOfWork.BookingRepository.GetBookingsWithRoomByCustomerEmail(request.Email);
            // mapping full data about 'booking type'
            var fullInfo = _mapper.Map<List<RoomTypeInfoWithUserBookedDTO>>(typeInfo);
            // adding user bookings to each type (to show on which types did user book)
            foreach (var dto in fullInfo)
            {
                dto.BookingsWithRoomTypes = new List<BookingWithRoomTypeDTO>();
                foreach (var booking in userBookings)
                {
                    if (dto.Id == booking.Room.RoomTypeId)
                    {
                        dto.BookingsWithRoomTypes.Add(_mapper.Map<BookingWithRoomTypeDTO>(booking));
                    }
                }
            }
            return fullInfo;
        }
    }
}
