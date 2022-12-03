using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TheScene.Core.Models.Event;
using TheScene.Core.Models.PerfomanceModels;

namespace TheScene.Models
{
    public class AllPerfomanceQueryModel
    {
        public const int PerfomancePerPage = 3;

        public string? Genre { get; set; }

        [Display(Name = "Type")]
        public string? PerfomanceType { get; set; }

        [Display(Name = "Search")]
        public string? SearchTerm { get; set; }

        public PerfomanceSotring Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPerfomanceCount { get; set; }

        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<string> PerfomanceTypes { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<AllPerfomanceModel> Perfomances { get; set; } = Enumerable.Empty<AllPerfomanceModel>();
    }
}