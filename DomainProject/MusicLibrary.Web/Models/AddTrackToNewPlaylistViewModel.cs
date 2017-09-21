using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Web.Models
{
    public class AddTrackToNewPlaylistViewModel
    {
        [Range(1, int.MaxValue)]
        public int TrackId { get; set; }

        [Required]
        [StringLength(30)]
        public string NewPlaylistName { get; set; }
    }
}