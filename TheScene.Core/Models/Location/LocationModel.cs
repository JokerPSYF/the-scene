using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Common;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Core.Models.Location
{
    public class LocationModel
    {
        public int Id { get; set; }

        [StringLength(LocationConstants.MaxName,
         MinimumLength = LocationConstants.MinName,
         ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        [StringLength(LocationConstants.MaxAddress,
         MinimumLength = LocationConstants.MinName,
         ErrorMessage = LengthErrorMessage)]
        public string Address { get; set; } = null!;

        [Range(
            maximum: LocationConstants.MaxSeats,
            minimum: LocationConstants.MinSeats,
            ErrorMessage = RangerErrorMessage)]
        public int? Seats { get; set; }

        [Display(Name = "Place Type")]
        public int PlaceTypeId { get; set; }

        [Display(Name = "Place Type")]
        public string? PlaceTypeName { get; set; }

        [RegularExpression(@"^(https:\/\/www.google.com\/maps\/embed\?.+)$",
            ErrorMessage = "Go to google maps, find your location -> Share -> Embed a map -> copy the src only of the link")]
        public string? Link { get; set; }

        public IEnumerable<NomenclatureDTO> PlaceTypes { get; set; } = new List<NomenclatureDTO>();
    }
}
