namespace TheScene.Core.Models.PerfomanceModels
{
    public class DeletePerfomanceModel
    {
        public string Title { get; set; } = null!;

        public string? Director { get; set; }

        public string Genre { get; set; } = null!;

        public string? Actors { get; set; }

        public string PerfomanceType { get; set; } = null!;

        public int? Year { get; set; }

        public string? ImageURL { get; set; }
    }
}
