using System.ComponentModel.DataAnnotations;

namespace TheScene.Core.Models.Event
{
    public class DeleteViewModel
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public string? Image { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Price per ticket")]
        public decimal PricePerTicket { get; set; }

        public bool IsPremiere { get; set; }
    }
}
