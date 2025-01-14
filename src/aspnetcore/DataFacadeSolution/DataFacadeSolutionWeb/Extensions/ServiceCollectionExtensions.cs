// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using DataFacadeRdbms;
using DataFacadeSolutionWeb.Helpers;
using DataFacadeSolutionWeb.Repositories;
using DataFacadeSolutionWeb.Services;

namespace DataFacadeSolutionWeb.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDepedencies(this IServiceCollection services)
        {
            services.AddScoped<IConfigSetting, ConfigSetting>();
            services.AddScoped<IDataFacade, SqlClientDataFacade>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
