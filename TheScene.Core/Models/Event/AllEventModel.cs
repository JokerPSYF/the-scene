using System.ComponentModel.DataAnnotations;

namespace TheScene.Core.Models.Event
{
    public class AllEventModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string PerfomanceTitle { get; set; } = null!;

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; } = null!;

        [Display(Name = "Price per ticket")]
        public decimal PricePerTicket { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Premiere")]
        public bool IsPremiere { get; set; }
    }
}