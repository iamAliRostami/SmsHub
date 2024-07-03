namespace SmsHub.Core.Application.Features.Events.Queries.GetEventsList
{
    public class EventListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
