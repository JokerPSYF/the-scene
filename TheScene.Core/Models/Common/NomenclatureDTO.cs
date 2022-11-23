namespace TheScene.Core.Models.Common
{
    public class NomenclatureDTO<T>
    {
        public T Value { get; set; }

        public string DisplayName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
