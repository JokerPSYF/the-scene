using System.ComponentModel.DataAnnotations;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Infrastructure.Data.Entities
{
    /// <summary>
    /// We will have different types of places.
    /// Like: cinema, theater, arena  etc.
    /// </summary>
    public class PlaceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PlaceTypeConstants.MaxName, MinimumLength = PlaceTypeConstants.MinName, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}