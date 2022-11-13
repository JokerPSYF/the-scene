using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Infrastructure.Data.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LocationConstants.MaxAddress, MinimumLength = LocationConstants.MinAddress, ErrorMessage = LengthErrorMessage)]
        public string Address { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(PlaceType))]
        public int PlaceTypeId { get; set; }

        public virtual PlaceType PlaceType { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
        // how many seats ?
    }
}
