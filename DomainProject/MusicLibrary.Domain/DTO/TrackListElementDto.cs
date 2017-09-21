using System;

namespace MusicLibrary.Domain.DTO
{
    public class TrackListElementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlId { get; set; }
        public string UploaderAlias { get; set; }
        public string UploaderUserName { get; set; }
        public int Likes { get; set; }
        public string Artwork { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}