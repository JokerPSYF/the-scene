using System.ComponentModel.DataAnnotations;
using TheScene.Infrastructure.Data.Entities;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Core.Models.Event
{
    public class AddEventModel
    {
        public int Id { get; set; }

        [Required]
        public int PerfomanceId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Range(
            maximum: EventConstants.MaxPrice,
            minimum:  EventConstants.MinPrice,
            ErrorMessage = EventConstants.RangerErrorMessage)]
        public decimal PricePerTicket { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public bool IsPremiere { get; set; }

        public IEnumerable<Location> Locations { get; set; } = new List<Location>();

        public IEnumerable<Perfomance> Perfomances { get; set; } = new List<Perfomance>();
    }
}
