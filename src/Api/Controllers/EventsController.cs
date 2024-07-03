using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Utility;
using SmsHub.Core.Application.Features.Events.Commands.CreateEvent;
using SmsHub.Core.Application.Features.Events.Queries.GetEventsExport;
using SmsHub.Core.Application.Features.Events.Queries.GetEventsList;

namespace SmsHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<CreateEventCommandResponse>> Create([FromBody]
        CreateEventCommand createEventCommand)
        {
            var response = await _mediator.Send(createEventCommand);
            return Ok(response);
        }

        [HttpGet("all",Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListDto>>> GetAllEvents() {
            var dtos = await _mediator.Send(new GetEventListQuery());
            return Ok(dtos);
        }

        [HttpGet("export", Name = "ExportAllEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents() {
            var fileDto = await _mediator.Send(new GetEventsExportQuery());
            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
        }
    }
}