using SmsHub.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Application.Contracts.Persistence
{
    public interface IEventRepository:IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime date);
    }
}
