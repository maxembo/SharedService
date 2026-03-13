using DirectoryService.Application.Constants;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharedService.Core.Caching;

public static class CacheExtensions
{
    private const string REDIS_CONNECTION_STRING = "Redis";

    public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheOptions = configuration
            .GetSection(CacheOptions.SECTION_NAME)
            .Get<CacheOptions>();

        services.AddStackExchangeRedisCache(
            options =>
            {
                string connection = configuration.GetConnectionString(REDIS_CONNECTION_STRING)
                                    ?? throw new ArgumentNullException(nameof(connection));

                options.Configuration = connection;
            });

        services.AddHybridCache(
            options =>
            {
                options.DefaultEntryOptions = new HybridCacheEntryOptions()
                {
                    LocalCacheExpiration = cacheOptions!.LocalCacheExpiration, Expiration = cacheOptions.Expiration,
                };
            });

        return services;
    }
}