namespace CarfyOrcamento.Core.Response;

public class PagedResponse<TData>
{
    public PagedResponse(IEnumerable<TData> data, int totalCount, int pageNumber, int pageSize )
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        Data = data;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int TotalCount { get; set; }
    public IEnumerable<TData> Data { get; set; }
    
}