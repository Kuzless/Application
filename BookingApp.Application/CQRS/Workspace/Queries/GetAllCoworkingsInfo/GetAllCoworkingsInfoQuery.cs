using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Workspace.GetAllCoworkingsInfo;
using MediatR;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllCoworkingsInfo
{
    public class GetAllCoworkingsInfoQuery : IRequest<OperationResult<List<CoworkingInfoDTO>>>
    {
    }
}
