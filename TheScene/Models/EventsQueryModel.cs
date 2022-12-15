using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Event;

namespace TheScene.Models
{
    public class EventsQueryModel
    {
        public const int EventsPerPage = 5;

        public string? Genre { get; set; }

        public string? PerfomanceType { get; set; }

        [Display(Name = "Search")]
        public string? SearchTerm { get; set; }

        public EventSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalEventsCount { get; set; }

        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<AllEventModel> Events { get; set; } = Enumerable.Empty<AllEventModel>();
    }
}
