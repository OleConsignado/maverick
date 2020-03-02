using Maverick.Application;
using Maverick.Domain.Services;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (applicationConfiguration == null)
            {
                throw new ArgumentNullException(nameof(applicationConfiguration));
            }

            services.AddSingleton(applicationConfiguration);

            services.AddScoped<IFilmesService, FilmesService>();

            return services;
        }
    }
}
