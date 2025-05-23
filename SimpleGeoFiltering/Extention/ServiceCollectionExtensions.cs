using Microsoft.Extensions.DependencyInjection;
using SimpleGeoFiltering.Interfaces;
using SimpleGeoFiltering.Services;

namespace SimpleGeoFiltering.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSimpleGeoFiltering(this IServiceCollection services)
        {
            services.AddScoped<IGeoFilterService, GeoFilterService>();
            return services;
        }

    }
}
