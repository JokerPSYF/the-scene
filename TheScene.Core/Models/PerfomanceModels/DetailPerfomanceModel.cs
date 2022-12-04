namespace TheScene.Core.Models.PerfomanceModels
{
    public class DetailPerfomanceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Director { get; set; } //CHECK

        public int GenreId { get; set; }

        public string Genre { get; set; } = null!;

        public string? Actors { get; set; } // CHECK

        public int PerfomanceTypeId { get; set; }

        public string PerfomanceType { get; set; } = null!;

        public int? Year { get; set; } //CHECK

        public string? ImageURL { get; set; }

        public string? Description { get; set; }
    }
}
