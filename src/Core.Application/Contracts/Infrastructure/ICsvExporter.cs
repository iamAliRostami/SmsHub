using SmsHub.Core.Application.Features.Events.Query.GetEventsExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
