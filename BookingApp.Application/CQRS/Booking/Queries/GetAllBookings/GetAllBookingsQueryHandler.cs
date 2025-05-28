using AutoMapper;
using BookingApp.Application.DTOs.Booking;
using BookingApp.Domain.Interfaces;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<BookingDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllBookingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<BookingDTO>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAll();
            return _mapper.Map<List<BookingDTO>>(bookings);
        }
    }
}
