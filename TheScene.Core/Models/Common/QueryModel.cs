namespace TheScene.Core.Models.Common
{
    public class QueryModel<T> where T : class
    {
        public int TotalCount { get; set; }

        public IEnumerable<T> Collection { get; set; } = new List<T>();
    }
}
