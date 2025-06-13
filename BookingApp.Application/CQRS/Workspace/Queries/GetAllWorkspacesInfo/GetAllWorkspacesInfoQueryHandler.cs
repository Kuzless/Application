using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Workspace.GetAllWorkspacesInfo;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllWorkspacesInfo
{
    public class GetAllWorkspacesInfoQueryHandler : IRequestHandler<GetAllWorkspacesInfoQuery, OperationResult<List<BookingTypeInfoDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        public GetAllWorkspacesInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, [FromKeyedServices("workspace")] IResponseHandlerService responseHandler)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult<List<BookingTypeInfoDTO>>> Handle(GetAllWorkspacesInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var typeInfo = await _unitOfWork.RoomTypeRepository.GetRoomTypesWithFullInfoByCoworkingId(request.CoworkingId);
                var userBookings = await _unitOfWork.BookingRepository.GetBookingsWithRoomByUserId(request.CoworkingId, request.UserId);
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
                return _responseHandler.Handle(200, data: fullInfo);
            }
            catch
            {
                return _responseHandler.Handle<List<BookingTypeInfoDTO>>(500, "An error occurred while retrieving data");
            }
        }
    }
}
