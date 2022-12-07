using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Common;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Core.Models.Event
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Perfomance")]
        public int PerfomanceId { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Range(
            maximum: (double)EventConstants.MaxPrice,
            minimum: (double)EventConstants.MinPrice,
            ErrorMessage = RangerErrorMessage)]
        [Display(Name = "Price per ticket")]
        [Precision(18, 2)]
        [DataType(DataType.Currency)]
        public decimal PricePerTicket { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Premiere")]
        public bool IsPremiere { get; set; }

        public IEnumerable<NomenclatureDTO> Locations { get; set; } = new List<NomenclatureDTO>();

        public IEnumerable<NomenclatureDTO> Perfomances { get; set; } = new List<NomenclatureDTO>();
    }
}
