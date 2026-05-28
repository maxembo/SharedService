using System.Text.Json.Serialization;

namespace SharedService.SharedKernel.Response;

public record PaginationEnvelope<T>
{
    public T[] Items { get; init; } = [];

    public long TotalCount { get; init; }

    public int Page { get; init; }

    public int PageSize { get; init; }

    public int TotalPages =>
        PageSize == 0
            ? 0
            : (int)Math.Ceiling((double)TotalCount / PageSize);

    [JsonConstructor]
    public PaginationEnvelope(T[]? items, long totalCount, int page, int pageSize)
    {
        Items = items ?? [];
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }

    public PaginationEnvelope(IEnumerable<T>? items, long totalCount, int page, int pageSize)
        : this(items?.ToArray() ?? [], totalCount, page, pageSize)
    { }
}