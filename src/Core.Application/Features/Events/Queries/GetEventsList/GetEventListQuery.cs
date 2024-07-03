using MediatR;

namespace SmsHub.Core.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventListQuery : IRequest<List<EventListDto>>
    {
    }
}
