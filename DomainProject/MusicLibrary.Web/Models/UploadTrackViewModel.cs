using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Web.Models
{
    public class UploadTrackViewModel
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }
        
        public string Artwork { get; set; }

        public int? YearReleased { get; set; }
    }
}