using System.Linq;

namespace BookManagement.Data
{
    public class ResultData<T>
    {
        public int TotalPage { get; set; } = 0;
        public int PageCount { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
        public IQueryable<T> ListData { get; set; }
    }
}