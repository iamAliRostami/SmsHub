using AutoMapper;
using MediatR;
using SmsHub.Core.Application.Contracts.Persistence;
using SmsHub.Core.Domain.Entity;

namespace SmsHub.Core.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) : IRequestHandler<GetEventListQuery,
        List<EventListDto>>
    {
        private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;

      public  async Task<List<EventListDto>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Id);
            return _mapper.Map<List<EventListDto>>(allEvents);
        }
    }
}
