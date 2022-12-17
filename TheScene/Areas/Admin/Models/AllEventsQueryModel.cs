using System.ComponentModel.DataAnnotations;
using TheScene.Models;

namespace TheScene.Areas.Admin.Models
{
    /// <summary>
    /// All Events, the admin can 
    /// </summary>
    public class AllEventsQueryModel : EventsQueryModel
    {
        public IEnumerable<string> PerfomanceTypes { get; set; } = Enumerable.Empty<string>();
    }
}
