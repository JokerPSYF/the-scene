using System.ComponentModel.DataAnnotations;

namespace TheScene.Core.Models.Event
{
    public class AllEventModel
    {
        public int Id { get; set; }

        public string PerfomanceTitle { get; set; } = null!;

        public string LocationName { get; set; } = null!;

        public decimal PricePerTicket { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public bool IsPremiere { get; set; }
    }
}
