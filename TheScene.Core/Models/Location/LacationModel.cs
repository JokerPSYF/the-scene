using System.ComponentModel.DataAnnotations;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Core.Models.Location
{
    public class LacationModel
    {
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
        public int Seats { get; set; }

        public int PlaceTypeId { get; set; }
    }
}
