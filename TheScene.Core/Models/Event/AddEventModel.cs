using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Common;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Core.Models.Event
{
    public class AddEventModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Perfomance")]
        public int PerfomanceId { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Range(
            maximum: EventConstants.MaxPrice,
            minimum: EventConstants.MinPrice,
            ErrorMessage = EventConstants.RangerErrorMessage)]
        [Display(Name = "Price per ticket")]
        public decimal PricePerTicket { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Premiere")]
        public bool IsPremiere { get; set; }

        public IEnumerable<NomenclatureDTO> Locations { get; set; } = new List<NomenclatureDTO>();

        public IEnumerable<NomenclatureDTO> Perfomances { get; set; } = new List<NomenclatureDTO>();
    }
}
