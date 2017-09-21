using System.Collections.Generic;

namespace MusicLibrary.Domain.DTO
{

    public class PlaylistWithTracksDto
    {
        public string CreatorAlias { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public int PlaylistId { get; set; }

        public IList<TrackListElementDto> Tracks { get; set; }
    }
}