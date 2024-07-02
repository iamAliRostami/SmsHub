using MediatR;

namespace SmsHub.Core.Application.Features.Events.Query.GetEventsExport
{
    public class GetEventsExportQuery:IRequest<EventExportFileVm>
    {
    }
}
