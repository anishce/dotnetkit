using Enyim.Caching.Configuration;

namespace CachingKit.Web.UI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMemcached(this IServiceCollection services, IConfiguration configuration)
        {
            string cachingServer = configuration.GetValue<string>("Caching:Memcached:ServerHost") ?? string.Empty;
            int cachingServerPort = configuration.GetValue<int>("Caching:Memcached:ServerPort");

            return services.AddEnyimMemcached(o => o.Servers = new List<Server> { new Server { Address = cachingServer, Port = cachingServerPort } });
        }
    }
}
