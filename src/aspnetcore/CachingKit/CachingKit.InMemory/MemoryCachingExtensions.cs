// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using CachingKitBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CachingKit.InMemory
{
    public static class MemoryCachingExtensions
    {
        public static void AddInMemoryCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICacheStrategy, InMemoryCacheStrategy>();
            // Register the HybridCacheStrategy as the implementation of ICacheStrategy
            //services.AddScoped<ICacheStrategy, HybridCache>();
            // Optionally, you can also register any dependencies required by HybridCacheStrategy here
            // For example, if HybridCacheStrategy depends on other services, you can register them as well
        }
    }
}
