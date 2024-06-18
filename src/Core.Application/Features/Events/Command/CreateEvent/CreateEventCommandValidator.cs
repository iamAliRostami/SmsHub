using FluentValidation;
using SmsHub.Core.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventCommandValidator:AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is require.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} max length is 50");

            RuleFor(e => e).MustAsync(EventNameAndDateUnique).WithMessage("");
            
        }
        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token) {
            return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
        }
    }
}
