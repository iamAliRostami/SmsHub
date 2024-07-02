using AutoMapper;
using SmsHub.Core.Application.Features.Events.Command.CreateEvent;
using SmsHub.Core.Application.Features.Events.Query.GetEventsExport;
using SmsHub.Core.Application.Features.Events.Query.GetEventsList;
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
