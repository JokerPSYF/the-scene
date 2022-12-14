using TheScene.Core.Models.Location;
using TheScene.Core.Models.PerfomanceModels;

namespace TheScene.Core.Models.Event
{
    public class DetailEventModel
    {
        public int Id { get; set; }

        public DetailPerfomanceModel Perfomance { get; set; } = null!;

        public LocationModel Location { get; set; }

        //public int LocationId { get; set; }

        //public string LocationName { get; set; } = null!;

        //public string Address { get; set; } = null!;

        public decimal PricePerTicket { get; set; }

        public DateTime Date { get; set; }

        public bool IsPremiere { get; set; }
    }
}
