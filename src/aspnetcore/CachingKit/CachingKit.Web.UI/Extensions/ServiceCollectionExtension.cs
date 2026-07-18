using CachingKit.InMemory;
using Enyim.Caching.Configuration;

namespace CachingKit.Web.UI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add In-Memory Caching
            services.AddInMemoryCaching(configuration);

            //Add Memcached Caching

            //Add Redis Caching

            //Add Hybrid Caching

            return services;
        }
    }
}
