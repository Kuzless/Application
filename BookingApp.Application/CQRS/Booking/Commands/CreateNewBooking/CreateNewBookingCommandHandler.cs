using AutoMapper;
using BookingApp.Domain.Interfaces;
using MediatR;

namespace BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking
{
    public class CreateNewBookingCommandHandler : IRequestHandler<CreateNewBookingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateNewBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateNewBookingCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.BookingRepository.Add(_mapper.Map<Domain.Entities.Booking>(request));
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
