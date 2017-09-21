namespace MusicLibrary.Domain.Models
{
    public class PageData
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PageData(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
