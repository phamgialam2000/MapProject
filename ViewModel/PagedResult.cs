namespace MapProject.ViewModel
{
    public class PagedResult : IPagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public interface IPagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}