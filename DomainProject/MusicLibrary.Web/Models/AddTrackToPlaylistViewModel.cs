using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Web.Models
{
    public class AddTrackToExistingPlaylistViewModel
    {
        [Range(1, int.MaxValue)]
        public int TrackId { get; set; }

        [Range(1, int.MaxValue)]
        public int ExistingPlaylistId { get; set; }
    }
}