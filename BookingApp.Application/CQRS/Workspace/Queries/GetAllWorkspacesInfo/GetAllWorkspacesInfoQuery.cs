using BookingApp.Application.DTOs;
using MediatR;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllWorkspacesInfo
{
    public class GetAllWorkspacesInfoQuery : IRequest<OperationResult<List<GetAllWorkspacesInfoQueryDTO>>> 
    {
        public string UserId { get; set; }
        public int CoworkingId { get; set; }
    }
}
