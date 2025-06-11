using AutoMapper;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Workspace.GetAllCoworkingsInfo;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllCoworkingsInfo
{
    public class GetAllCoworkingsInfoQueryHandler : IRequestHandler<GetAllCoworkingsInfoQuery, OperationResult<List<CoworkingInfoDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        public GetAllCoworkingsInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, [FromKeyedServices("workspace")] IResponseHandlerService responseHandler)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult<List<CoworkingInfoDTO>>> Handle(GetAllCoworkingsInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var coworkings = await _unitOfWork.CoworkingRepository.GetCoworkingsInfoWithTypesAndRooms();
                var result = _mapper.Map<List<CoworkingInfoDTO>>(coworkings);
                for (int i = 0; i < coworkings.Count; i++)
                {
                    result[i].RoomTypesWithRooms = coworkings[i].Rooms.GroupBy(r => r.RoomType)
                        .Select(g => new RoomTypeWithRoomsDTO
                        {
                            RoomType = _mapper.Map<RoomTypeDTO>(g.Key),
                            Rooms = g.Select(r => _mapper.Map<RoomDTO>(r)).ToList()
                        }).ToList();
                }
                return _responseHandler.Handle(200, data: result);
            }
            catch
            {
                return _responseHandler.Handle<List<CoworkingInfoDTO>>(500, "An error occurred while retrieving data");
            }
        }
    }
}
