using SmsHub.Core.Application.Features.Events.Query;
using SmsHub.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventCommandResponse:BaseResponse
    {
        public CreateEventDto @event { get; set; } = default!;
        public CreateEventCommandResponse():base()
        {
            
        }
    }
}
