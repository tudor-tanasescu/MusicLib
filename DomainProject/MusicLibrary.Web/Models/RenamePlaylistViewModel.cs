using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Web.Models
{
    public class RenamePlaylistViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int PlaylistId { get; set; }
    }
}