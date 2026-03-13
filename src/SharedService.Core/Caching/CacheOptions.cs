namespace DirectoryService.Application.Constants;

public record CacheOptions
{
    public const string SECTION_NAME = "CacheOptions";

    public TimeSpan LocalCacheExpiration { get; init; } = TimeSpan.FromMinutes(5);

    public TimeSpan Expiration { get; init; } = TimeSpan.FromMinutes(5);
}