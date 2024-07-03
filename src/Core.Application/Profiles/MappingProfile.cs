using AutoMapper;
using SmsHub.Core.Application.Features.Events.Commands.CreateEvent;
using SmsHub.Core.Application.Features.Events.Queries.GetEventsExport;
using SmsHub.Core.Application.Features.Events.Queries.GetEventsList;
using SmsHub.Core.Domain.Entity;

namespace SmsHub.Core.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();
        }
    }
}
