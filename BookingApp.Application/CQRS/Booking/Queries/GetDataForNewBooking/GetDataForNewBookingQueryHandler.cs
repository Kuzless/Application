using AutoMapper;
using BookingApp.Application.DTOs.Booking.GetDataForNewBooking;
using BookingApp.Domain.Interfaces;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking
{
    public class GetDataForNewBookingQueryHandler : IRequestHandler<GetDataForNewBookingQuery, List<NewBookingStructureDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetDataForNewBookingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<NewBookingStructureDTO>> Handle(GetDataForNewBookingQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithCapacity();
            return _mapper.Map<List<NewBookingStructureDTO>>(data);
        }
    }
}
