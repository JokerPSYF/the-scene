using System.ComponentModel.DataAnnotations;
using TheScene.Core.Models.Common;
using TheScene.Infrastructure.Data.Entities;
using static TheScene.Infrastructure.Data.Constants.DataConstants;

namespace TheScene.Core.Models.PerfomanceModels
{
    public class AddPerfomanceModel
    {
        public int Id { get; set; }

        [StringLength(
            PerfomanceConstants.MaxName,
            MinimumLength = PerfomanceConstants.MinName,
            ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [StringLength(PerfomanceConstants.MaxDirector, MinimumLength = PerfomanceConstants.MinDirector, ErrorMessage = LengthErrorMessage)]
        public string? Director { get; set; }

        public int GenreId { get; set; }

        [StringLength(
            PerfomanceConstants.MaxActors,
            MinimumLength = PerfomanceConstants.MinActors,
            ErrorMessage = LengthErrorMessage)]
        public string? Actors { get; set; }

        public int PerfomanceTypeId { get; set; }

        [StringLength(PerfomanceConstants.MaxDescription, ErrorMessage = LengthErrorMessage)]
        public string? Description { get; set; }

        [Range(minimum: PerfomanceConstants.MinYear,
               maximum: PerfomanceConstants.MaxYear,
               ErrorMessage = LengthErrorMessage)]
        public int? Year { get; set; }

        [StringLength(PerfomanceConstants.MaxImageURL)]
        public string? ImageURL { get; set; }

        public IEnumerable<NomenclatureDTO> Genres { get; set; } = new List<NomenclatureDTO>();
    }
}