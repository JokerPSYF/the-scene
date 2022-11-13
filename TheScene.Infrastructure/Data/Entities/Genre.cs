using System.ComponentModel.DataAnnotations;
using static TheScene.Infrastructure.Data.Constants.DataConstants.GenreConstants;

namespace TheScene.Infrastructure.Data.Entities
{
    /// <summary>
    /// Types of genres
    /// </summary>
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxName)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Perfomance> Perfomances { get; set; } = new List<Perfomance>();
    }
}