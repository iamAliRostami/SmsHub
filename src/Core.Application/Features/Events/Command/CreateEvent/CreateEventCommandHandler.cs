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
    public class CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        : IRequestHandler<CreateEventCommand, CreateEventCommandResponse>
    {
        private IMapper _mapper = mapper;
        private readonly IEventRepository _eventRepository = eventRepository;

        public async Task<CreateEventCommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var createEventCommandResponse = new CreateEventCommandResponse() ;
            
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
            {
                /*    throw new Exceptions.ValidationException(validatorResult); */
                createEventCommandResponse.Success = false;
                createEventCommandResponse.ValidationErrors = [];
                foreach (var error in validatorResult.Errors)
                {
                    createEventCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createEventCommandResponse.Success) {
                var @event = new Event() { Name = request.Name };
                @event = await _eventRepository.AddAsync(@event);
                createEventCommandResponse.@event = _mapper.Map<CreateEventDto>(@event);
            }
            /*var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);*/
            /*return @event.Id;*/
            return createEventCommandResponse;
        }
    }
}
