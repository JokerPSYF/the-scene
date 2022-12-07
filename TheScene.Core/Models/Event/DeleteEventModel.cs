using System.ComponentModel.DataAnnotations;

namespace TheScene.Core.Models.Event
{
    public class DeleteEventModel
    {
        public string Title { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
