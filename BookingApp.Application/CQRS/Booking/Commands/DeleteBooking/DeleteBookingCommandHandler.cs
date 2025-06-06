using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Booking.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, OperationResult<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResponseHandlerService _responseHandler;
        public DeleteBookingCommandHandler([FromKeyedServices("booking")] IResponseHandlerService responseHandler, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult<object>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.BookingRepository.GetById(request.Id);
                if (entity == null)
                {
                    return _responseHandler.Handle<object>(404);
                }
                _unitOfWork.BookingRepository.Delete(entity);
                var changesNum = await _unitOfWork.SaveChangesAsync();
                if (changesNum > 0)
                {
                    return _responseHandler.Handle<object>(200);
                }
                throw new Exception("An unexpected error occurred");
            } catch (Exception ex)
            {
                return _responseHandler.Handle<object>(500, ex.Message);
            }
        }
    }
}
