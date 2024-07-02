using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Query.GetEventsList
{
    public class EventListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
