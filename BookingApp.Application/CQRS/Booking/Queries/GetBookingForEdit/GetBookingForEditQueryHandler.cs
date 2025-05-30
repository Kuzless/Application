using AutoMapper;
using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using BookingApp.Domain.Interfaces;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit
{
    public class GetBookingForEditQueryHandler : IRequestHandler<GetBookingForEditQuery, BookingWithAllRoomTypesDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetBookingForEditQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingWithAllRoomTypesDTO> Handle(GetBookingForEditQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithCapacity();
            var booking = await _unitOfWork.BookingRepository.GetById(request.Id);
            var responseData = _mapper.Map<BookingWithAllRoomTypesDTO>(booking);
            responseData.RoomTypes = _mapper.Map<List<RoomTypeWithCapacitiesDTO>>(data);
            return responseData;
        }
    }
}
