﻿namespace SmsHub.Core.Application.Features.Events.Queries.GetEventsExport
{
    public class EventExportDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
