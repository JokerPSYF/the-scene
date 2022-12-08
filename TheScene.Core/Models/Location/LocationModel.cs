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

        public IEnumerable<NomenclatureDTO> PlaceTypes { get; set; } = new List<NomenclatureDTO>();
    }
}
