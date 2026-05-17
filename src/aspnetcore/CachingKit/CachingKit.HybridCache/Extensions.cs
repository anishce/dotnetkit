// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using CachingKitBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingKit.HybridCache
{
    public static class Extensions
    {
        public static void AddHybridCache(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the HybridCacheStrategy as the implementation of ICacheStrategy
            services.AddScoped<ICacheStrategy, HybridCache>();
            // Optionally, you can also register any dependencies required by HybridCacheStrategy here
            // For example, if HybridCacheStrategy depends on other services, you can register them as well
        }
    }
}
