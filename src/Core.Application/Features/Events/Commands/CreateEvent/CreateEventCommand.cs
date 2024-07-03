using MediatR;
namespace SmsHub.Core.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand:IRequest<CreateEventCommandResponse>
    {
        public string Name{ get; set;} = string.Empty;
        public DateTime Date { get; set; }
        public override string ToString(){
            return $"Event name {Name}";
        }
    }
    
}
