using MediatR;

namespace SmsHub.Core.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery:IRequest<EventExportFileVm>
    {
    }
}
