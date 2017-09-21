namespace MusicLibrary.Domain.DTO
{
    public class AddToPlaylistDto
    {
        public string Artwork { get; set; }
        public int PlaylistId { get; set; }
        public string UrlId { get; set; }
        public string Name { get; set; }
        public string CreatorUserName { get; set; }
        public bool HasTrack { get; set; }
    }
}