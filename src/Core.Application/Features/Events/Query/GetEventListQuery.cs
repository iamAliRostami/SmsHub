using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Features.Events.Query
{
    public class GetEventListQuery:IRequest<List<GetEventListDto>>
    {
    }
}
