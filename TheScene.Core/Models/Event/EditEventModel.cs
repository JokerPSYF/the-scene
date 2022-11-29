using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheScene.Infrastructure.Data.Entities;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Core.Models.Event
{
    public class EditEventModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Perfomance))]
        public int PerfomanceId { get; set; }

        [Required]
        [Display(Name = nameof(Location))]
        public int LocationId { get; set; }

        [Display(Name = "Occupied seats")]
        [Range(EventConstants.MinSeats, EventConstants.MaxSeats, ErrorMessage = EventConstants.RangerErrorMessage)]
        public int? OccupiedSeats { get; set; }

        [Display(Name = "Free seats")]
        [Range(EventConstants.MinSeats, EventConstants.MaxSeats, ErrorMessage = EventConstants.RangerErrorMessage)]
        public int? FreeSeats { get; set; }

        [Required]
        [Display(Name = "Price per ticket")]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        [Range(EventConstants.MinPrice, EventConstants.MaxPrice, ErrorMessage = EventConstants.RangerErrorMessage)]
        public decimal PricePerTicket { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public bool? IsPremiere { get; set; } = false;
    }
}
