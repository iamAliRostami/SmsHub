using AutoMapper;
using MediatR;
using SmsHub.Core.Application.Contracts.Persistence;
using SmsHub.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Query.GetEventsList
{
    public class GetEventListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) : IRequestHandler<GetEventListQuery,
        List<EventListDto>>
    {
        private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;

        async Task<List<EventListDto>> IRequestHandler<GetEventListQuery, List<EventListDto>>.Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Id);
            return _mapper.Map<List<EventListDto>>(allEvents);
        }
    }
}
