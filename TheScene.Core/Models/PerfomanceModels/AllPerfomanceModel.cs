namespace TheScene.Core.Models.PerfomanceModels
{
    /// <summary>
    /// Perfomance view model that will show all the perfomance
    /// </summary>
    public class AllPerfomanceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Director { get; set; }

        public string Genre { get; set; } = null!;

        public string? Actors { get; set; }

        public string PefomanceType { get; set; } = null!;

        public int? Year { get; set; }

        public string? ImageUrl { get; set; }
    }
}
