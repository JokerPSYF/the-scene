using System.ComponentModel.DataAnnotations;
using TheScene.Infrastructure.Data.Entities;

namespace TheScene.Core.Models.Event
{
    public class AddEventModel
    {
        public int Id { get; set; }

        public Perfomance Perfomance { get; set; } = null!;

        public Location LocationName { get; set; } = null!;

        public decimal PricePerTicket { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public bool IsPremiere { get; set; }
    }
}
