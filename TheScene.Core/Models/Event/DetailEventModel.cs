using TheScene.Core.Models.PerfomanceModels;

namespace TheScene.Core.Models.Event
{
    public class DetailEventModel
    {
        public int Id { get; set; }

        public DetailPerfomanceModel Perfomance { get; set; } = null!;

        public string LocationName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int? OccupiedSeats { get; set; } = 0;

        public int? FreeSeats { get; set; }

        public decimal PricePerTicket { get; set; }

        public DateTime Date { get; set; }

        public bool IsPremiere { get; set; }
    }
}
