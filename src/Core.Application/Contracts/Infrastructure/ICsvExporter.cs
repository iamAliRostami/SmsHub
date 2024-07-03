using SmsHub.Core.Application.Features.Events.Queries.GetEventsExport;

namespace SmsHub.Core.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
