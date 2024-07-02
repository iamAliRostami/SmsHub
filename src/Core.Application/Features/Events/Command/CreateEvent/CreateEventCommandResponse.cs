using SmsHub.Core.Application.Responses;

namespace SmsHub.Core.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventCommandResponse:BaseResponse
    {
        public EventDto @event { get; set; } = default!;
        public CreateEventCommandResponse():base()
        {
        }
    }
}
