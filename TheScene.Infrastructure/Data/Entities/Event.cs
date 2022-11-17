using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Infrastructure.Data.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Perfomance))]
        public int PerfomanceId { get; set; }

        public virtual Perfomance Perfomance { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; } = null!;

        [Range(EventConstants.MinSeats, EventConstants.MaxSeats, ErrorMessage = EventConstants.RangerErrorMessage)]
        public int? OccupiedSeats { get; set; }

        [Range(EventConstants.MinSeats, EventConstants.MaxSeats, ErrorMessage = EventConstants.RangerErrorMessage)]
        public int? FreeSeats { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18,2)]
        public decimal PricePerTicket { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsPremiere { get; set; } = false;

        /// <summary>
        /// It is deleted or not?
        /// </summary>
        public bool IsActive { get; set; } = true;

        //can we sell tickets? or only to make reservations?
    }
}
