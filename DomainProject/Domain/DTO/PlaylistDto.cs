namespace MusicLibrary.Domain.DTO
{
    public class PlaylistDto
    {
        public string CreatorAlias { get; set; }
        public string CreatorUserName { get; set; }
        public int PlaylistId { get; set; }
        public string UrlId { get; set; }
        public string Name { get; set; }
        public string Artwork { get; set; }
    }
}