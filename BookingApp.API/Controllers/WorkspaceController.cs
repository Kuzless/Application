using BookingApp.API.Interfaces;
using BookingApp.Application.CQRS.Workspace.Queries.GetAllCoworkingsInfo;
using BookingApp.Application.CQRS.Workspace.Queries.GetAllWorkspacesInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IApiResponseHandler _apiResponseHandler;

        public WorkspaceController(IMediator mediator, IApiResponseHandler apiResponseHandler)
        {
            _apiResponseHandler = apiResponseHandler;
            _mediator = mediator;
        }

        // retrieves coworkings with all additional info
        [HttpGet]
        public async Task<IActionResult> GetCoworkingsInfo()
        {
            var coworking = await _mediator.Send(new GetAllCoworkingsInfoQuery());
            return _apiResponseHandler.Handle(coworking);
        }

        // retrieves workspaces with all additional info
        // userid is needed to retrieve info about bookings that user booked
        [HttpGet("{coworkingId}/{userId}")]
        public async Task<IActionResult> GetWorkspacesInfo(int coworkingId, string userId)
        {
            var bookings = await _mediator.Send(new GetAllWorkspacesInfoQuery() { UserId = userId, CoworkingId = coworkingId });
            return _apiResponseHandler.Handle(bookings);
        }
    }
}
