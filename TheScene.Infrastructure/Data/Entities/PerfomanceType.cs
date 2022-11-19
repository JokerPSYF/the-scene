using System.ComponentModel.DataAnnotations;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Infrastructure.Data.Entities
{
    /// <summary>
    /// We will show different types of perfomances.
    /// Like: movie, theatrical perfomance, concert, opera etc.
    /// </summary>
    public class PerfomanceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(
            PerfomanceTypeConstants.MaxName,
            MinimumLength = PerfomanceTypeConstants.MinName,
            ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;
        
        public virtual ICollection<Perfomance> Perfomances { get; set; } = new List<Perfomance>();
    }
}