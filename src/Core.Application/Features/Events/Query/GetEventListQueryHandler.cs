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
        List<GetEventListDto>>
    {
        private readonly IAsyncRepository<Event> _eventRepository = eventRepository;
        private readonly IMapper _mapper = mapper;

        async Task<List<GetEventListDto>> IRequestHandler<GetEventListQuery, List<GetEventListDto>>.Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepository.GetAllAsync()).OrderBy(x => x.Id);
            return _mapper.Map<List<GetEventListDto>>(allEvents);
        }
    }
}
