using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Infrastructure.Data.Entities
{
    public class Perfomance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PerfomanceConstants.MaxName, MinimumLength = PerfomanceConstants.MinName, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Director name of the perfomance
        /// </summary>
        [StringLength(PerfomanceConstants.MaxDirector, MinimumLength = PerfomanceConstants.MinDirector, ErrorMessage = LengthErrorMessage)]
        public string? Director { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;

        /// <summary>
        /// Actor's names who play in the perfomance
        /// it will add them like string because we need them only like info.
        /// </summary>
        [StringLength(PerfomanceConstants.MaxActors, MinimumLength = PerfomanceConstants.MinActors, ErrorMessage = LengthErrorMessage)]
        public string? Actors { get; set; }

        [Required]
        [ForeignKey(nameof(PerfomanceType))]
        public int PerfomanceTypeId { get; set; }

        public virtual PerfomanceType PerfomanceType { get; set; } = null!;

        [StringLength(PerfomanceConstants.MaxDescription, ErrorMessage = LengthErrorMessage)]
        public string? Description { get; set; }

        [StringLength(PerfomanceConstants.MaxImageURL)]
        public string? ImageURL { get; set; }

        /// <summary>
        /// It is deleted or not?
        /// </summary>
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    }
}