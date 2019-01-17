using Maverick.Domain.Adapters;
using Maverick.Tmdb.Adapter;
using Maverick.Tmdb.Adapter.Adaptee;
using Otc.Networking.Http.Client.Abstractions;
using Refit;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TmdbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddTmdbAdapter(this IServiceCollection services, TmdbAdapterConfiguration tmdbAdapterConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (tmdbAdapterConfiguration == null)
                throw new ArgumentNullException(nameof(tmdbAdapterConfiguration));

            // Registra a instancia do objeto de configuracoes desta camanda.
            services.AddSingleton(tmdbAdapterConfiguration);

            // Configura os parametros para chamada na TMDb API e registra a interface ITmdbApi.
            services.AddScoped(serviceProvider =>
            {
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateHttpClient();
                httpClient.BaseAddress = new Uri(tmdbAdapterConfiguration.TmdbApiUrlBase);

                return RestService.For<ITmdbApi>(httpClient);
            });

            // Registra a implementacao do ITmdbAdapter para ser utilizado na camada WebApi.
            services.AddScoped<ITmdbAdapter, TmdbAdapter>();

            return services;
        }
    }
}