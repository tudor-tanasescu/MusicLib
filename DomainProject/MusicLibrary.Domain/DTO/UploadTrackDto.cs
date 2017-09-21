namespace MusicLibrary.Domain.DTO
{
    public class UploadTrackDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Artwork { get; set; }
        public string UploaderUserName { get; set; }
        public int? YearReleased { get; set; }
    }
}
