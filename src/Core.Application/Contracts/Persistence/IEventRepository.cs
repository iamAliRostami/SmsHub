using SmsHub.Core.Domain.Entity;

namespace SmsHub.Core.Application.Contracts.Persistence
{
    public interface IEventRepository:IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime date);
    }
}