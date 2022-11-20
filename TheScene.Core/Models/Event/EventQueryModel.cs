namespace TheScene.Core.Models.Event
{
    public class EventQueryModel
    {
        public int TotalEventsCount { get; set; }

        public IEnumerable<AllEventModel> Events { get; set; } = new List<AllEventModel>();
    }
}
