// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CachingKit.Redis
{
    public static class RedisCacheExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("ConnectionStrings:RedisCacheConnection").Value;
                options.InstanceName = configuration.GetSection("Caching:Redis:InstanceName").Value ?? string.Empty;
            });

            return services;
        }
    }
}
