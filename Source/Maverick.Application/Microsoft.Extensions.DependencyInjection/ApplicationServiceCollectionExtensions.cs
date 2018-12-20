using Maverick.Application;
using Maverick.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (applicationConfiguration == null)
            {
                throw new ArgumentNullException(nameof(applicationConfiguration));
            }

            // Registra a instancia do objeto de configuracoes desta camanda.
            services.AddSingleton(applicationConfiguration);

            // Registra o servico descrito pela interface IFilmesService
            services.AddScoped<IFilmesService, FilmesService>();

            return services;
        }
    }
}
