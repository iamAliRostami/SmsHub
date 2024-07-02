using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Command.CreateEvent
{
    public class EventDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
