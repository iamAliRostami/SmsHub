﻿using AutoMapper;
using MediatR;
using SmsHub.Core.Application.Contracts.Infrastructure;
using SmsHub.Core.Application.Contracts.Persistence;
using SmsHub.Core.Domain.Entity;

namespace SmsHub.Core.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQueryHandler(IMapper mapper,
        IAsyncRepository<Event> repository, ICsvExporter csvExporter) :
        IRequestHandler<GetEventsExportQuery, EventExportFileVm>
    {
        private readonly IMapper _mapper= mapper;
        private readonly IAsyncRepository<Event> _eventRepository = repository;
        private readonly ICsvExporter _csvExporter = csvExporter;

        public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, 
            CancellationToken cancellationToken)
        {
            var allEvents = _mapper.Map<List<EventExportDto>>((await 
                _eventRepository.ListAllAsync()).OrderBy(x => x.Date));

            var fileData = _csvExporter.ExportEventsToCsv(allEvents);

            var eventExportFileDto = new EventExportFileVm() { 
                ContentType = "text/csv", 
                Data = fileData,
                EventExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
