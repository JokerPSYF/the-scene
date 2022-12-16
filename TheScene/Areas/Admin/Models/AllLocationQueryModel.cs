using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Location;

namespace TheScene.Models
{
    public class AllLocationQueryModel
    {
        public const int LocationsPerPage = 6;

        [Display(Name = "Search")]
        public string? SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalLocationCount { get; set; }

        [Display(Name = "Place Type")]
        public string? PlaceType { get; set; }

        public IEnumerable<string> PlaceTypes { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<LocationModel> Locations { get; set; } = Enumerable.Empty<LocationModel>();
    }
}
