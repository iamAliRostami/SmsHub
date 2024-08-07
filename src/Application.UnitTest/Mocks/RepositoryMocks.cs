using EmptyFiles;
using Moq;
using SmsHub.Core.Application.Contracts.Persistence;
using SmsHub.Core.Domain.Entity;

namespace SmsHub.Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {

        public static Mock<IAsyncRepository<Event>> GetEventRepository()
        {

            var mockCategoryRepository = new Mock<IAsyncRepository<Event>>();
            

            return mockCategoryRepository;
        }
    }
}
