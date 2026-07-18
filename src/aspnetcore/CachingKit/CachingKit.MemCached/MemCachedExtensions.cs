// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using Enyim.Caching.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CachingKit.MemCached
{
    public static class MemCachedExtensions
    {
        public static IServiceCollection AddMemcachedCaching(this IServiceCollection services, IConfiguration configuration)
        {
            string cachingServer = configuration.GetValue<string>("Caching:Memcached:ServerHost") ?? string.Empty;
            int cachingServerPort = configuration.GetValue<int>("Caching:Memcached:ServerPort");

            return services.AddEnyimMemcached(o => o.Servers = 
            [
                new() {
                    Address = cachingServer,
                    Port = cachingServerPort
                }
            ]);
        }
    }
}
