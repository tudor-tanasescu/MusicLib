using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Web.Models
{
    public class DeletePlaylistViewModel
    {
        [Range(0, int.MaxValue)]
        public int PlaylistId { get; set; }
    }
}