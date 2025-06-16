using BookingApp.Application.DTOs;
using MediatR;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllCoworkingsInfo
{
    public class GetAllCoworkingsInfoQuery : IRequest<OperationResult<List<GetAllCoworkingsInfoQueryDTO>>>
    {
    }
}
