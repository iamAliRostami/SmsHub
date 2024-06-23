using AutoMapper;
using SmsHub.Core.Application.Features.Events.Command.CreateEvent;
using SmsHub.Core.Application.Features.Events.Query;
using SmsHub.Core.Domain.Entity;

namespace SmsHub.Core.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, GetEventListDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, CreateEventDto>().ReverseMap();
        }
    }
}
