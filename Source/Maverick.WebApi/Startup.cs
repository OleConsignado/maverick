using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Maverick.Tmdb.Adapter;
using Otc.AspNetCore.ApiBoot;
using Otc.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using Maverick.Application;

namespace Maverick.WebApi
{
    /// <summary>
    /// Este eh o Startup da API. 
    /// <para>
    /// A base <see cref="ApiBootStartup"/> implementa uma serie de requisitos que consideramos
    /// necessarios para qualquer API, como Log, Swagger, Authorizacao, Versionamento e mais.
    /// Veja https://github.com/OleConsignado/otc-aspnetcore-apiboot para maiores detalhes (talvez a documentacao ainda esteja em construcao).
    /// </para>
    /// </summary>
    public class Startup : ApiBootStartup
    {
        protected override ApiMetadata ApiMetadata => new ApiMetadata()
        {
            Name = "Maverick",
            Description = "Exemplo de implementação de uma API de fachada para o TMDb API.",
            DefaultApiVersion = "1.0"
        };

        static Startup()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<TmdbMapperProfile>();
                config.AddProfile<WebApiMapperProfile>();
            });
        }


        public Startup(IConfiguration configuration)
            : base(configuration)
        {

        }

        /// <summary>
        /// Registra os servicos especificos da API.
        /// </summary>
        /// <param name="services"></param>
        [ExcludeFromCodeCoverage]
        protected override void ConfigureApiServices(IServiceCollection services)
        {
            services.AddTmdbAdapter(Configuration.SafeGet<TmdbAdapterConfiguration>());
            services.AddApplication(Configuration.SafeGet<ApplicationConfiguration>());
        }
    }
}
