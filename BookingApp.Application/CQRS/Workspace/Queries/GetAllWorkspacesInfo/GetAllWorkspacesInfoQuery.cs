using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Workspace.GetAllWorkspacesInfo;
using MediatR;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllWorkspacesInfo
{
    public class GetAllWorkspacesInfoQuery : IRequest<OperationResult<List<BookingTypeInfoDTO>>> 
    {
        public string UserId { get; set; }
        public int CoworkingId { get; set; }
    }
}
