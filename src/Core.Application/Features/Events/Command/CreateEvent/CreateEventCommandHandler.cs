using AutoMapper;
using MediatR;
using SmsHub.Core.Application.Contracts.Persistence;
using SmsHub.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository) : IRequestHandler<CreateEventCommand, Guid>
    {
        private IMapper _mapper = mapper;
        private readonly IEventRepository _eventRepository = eventRepository;

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);
            return @event.Id;
        }
    }
}
