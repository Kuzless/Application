using AutoMapper;
using BookingApp.Application.DTOs.Booking;
using BookingApp.Domain.Interfaces;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetBookingForEdit
{
    public class GetBookingForEditQueryHandler : IRequestHandler<GetBookingForEditQuery, BookingEditDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetBookingForEditQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingEditDTO> Handle(GetBookingForEditQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithCapacity();
            var booking = await _unitOfWork.BookingRepository.GetById(request.Id);
            var responseData = _mapper.Map<BookingEditDTO>(booking);
            responseData.RoomTypes = _mapper.Map<List<RoomTypesForNewBookingDTO>>(data);
            return responseData;
        }
    }
}
