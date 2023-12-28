using DataFacadeRdbms;

namespace DataFacadeSolutionWeb.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDepedencies(this IServiceCollection services)
        {
            services.AddTransient<IDataFacade, SqlClientDataFacade>();
            return services;
        }
    }
}
