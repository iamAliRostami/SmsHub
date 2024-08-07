using AutoMapper;
using Moq;
using Shouldly;
using SmsHub.Application.UnitTest.Mocks;
using SmsHub.Core.Application.Contracts.Persistence;
using SmsHub.Core.Application.Features.Events.Queries.GetEventsList;
using SmsHub.Core.Application.Profiles;
using SmsHub.Core.Domain.Entity;
using Xunit;

namespace SmsHub.Application.UnitTest.Events.Commands
{
    public class CreateEventTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Event>> _mockEventRepository;

        public CreateEventTests()
        {
            _mockEventRepository = RepositoryMocks.GetEventRepository();
            var configurationProvider = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetEventListTest() { 
        var  handler = new GetEventListQueryHandler(_mapper,_mockEventRepository.Object);
            var result = await handler.Handle(new GetEventListQuery(),CancellationToken.None);
            result.ShouldBeOfType<List<EventListDto>>();
            result.Count.ShouldBe(2);
        }
    }

}
