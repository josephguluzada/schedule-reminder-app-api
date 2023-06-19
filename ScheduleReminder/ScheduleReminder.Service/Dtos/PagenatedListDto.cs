namespace ScheduleReminder.Service.Dtos;

public class PagenatedListDto<T>
{
    public PagenatedListDto(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
    {
        this.Items = items;
        this.PageIndex = pageIndex;
        this.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        this.HasNext = this.PageIndex < this.TotalPages;
        this.HasPrev = this.PageIndex > 1;
    }


    public IEnumerable<T> Items { get;}
    public int PageIndex { get;}
    public int TotalPages { get; }
    public bool HasNext { get; set; }
    public bool HasPrev { get; set; }
}
