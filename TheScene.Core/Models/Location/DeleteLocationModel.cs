namespace TheScene.Core.Models.Location
{
    public class DeleteLocationModel
    {
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int? Seats { get; set; }

        public string PlaceType { get; set; } = null!;

        public string? Link { get; set; }
    }
}
