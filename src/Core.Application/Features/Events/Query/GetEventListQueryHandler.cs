using AutoMapper;
using MediatR;
using SmsHub.Core.Application.Contracts.Persistence;
using SmsHub.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Query
{
    public class GetEventListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) : IRequestHandler<GetEventListQuery,
        List<EventDto>>
    {
        private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;

        async Task<List<EventDto>> IRequestHandler<GetEventListQuery, List<EventDto>>.Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepository.GetAllAsync()).OrderBy(x => x.id);
            return _mapper.Map<List<EventDto>>(allEvents);
        }
    }
}
