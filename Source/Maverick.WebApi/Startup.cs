using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Maverick.TmdbAdapter;
using Otc.AspNetCore.ApiBoot;
using Otc.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using Maverick.Application;
using Maverick.Domain.Exceptions;
using System.Net;
using Maverick.WebApi.Dtos;
using Otc.DomainBase.Exceptions;
using System;

namespace Maverick.WebApi
{
    /// <summary>
    /// Este eh o Startup da API. 
    /// <para>
    /// A base <see cref="ApiBootStartup"/> implementa uma serie de requisitos
    /// que consideramos necessarios para qualquer API, como Log, Swagger,
    /// Authorizacao, Versionamento e mais.
    /// Veja https://github.com/OleConsignado/otc-aspnetcore-apiboot para maiores
    /// detalhes.
    /// </para>
    /// </summary>
    public class Startup : ApiBootStartup
    {
        protected override ApiMetadata ApiMetadata => new ApiMetadata()
        {
            Name = "Maverick",
            Description = "{{webAPIDescription}}",
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
        protected override void ConfigureApiServices(
            IServiceCollection services)
        {
            // Proposta de novo metodo ConfigureExceptionMappings (Otc.AspNetCore.ApiBoot.ApiBootStartup)

            // Pacotes afetados:
            // - Otc.AspNetCore.ApiBoot (https://github.com/OleConsignado/otc-aspnetcore-apiboot)
            // - Otc.ExceptionHandling (https://github.com/OleConsignado/otc-exception-handling)
            // - Otc.DomainBase (https://github.com/OleConsignado/otc-exception-handling)

            // Comportamentos
            // - Erro de cliente: Os dados do erro sao expostos na integralidade para o consumidor;
            //                    Detalhes do erro podem ser logados em nivel information.
            // - Erro de servidor: Um identificador (guid) deve ser gerado para o evento e os detalhes
            //                     sobre o erro precisam ser logados na integralidade (junto ao identificador);
            //                     A resposta para o consumidor nao deve incluir detalhes sobre o erro, apenas
            //                     o identificador deve ser fornecido (para rastreio).
            ConfigureExceptionMappings(

                // Comportamento de erro de cliente
                new ClientErrorExceptionMapping( 
                        exceptionType: typeof(BuscarFilmesCoreException),
                        responseModel: typeof(BuscarFilmesCoreExceptionDto),
                        responseCode: HttpStatusCode.BadRequest),
                // Obs.: Para mapeamento entre BuscarFilmesCoreException e BuscarFilmesCoreExceptionDto
                // proponho que seja configurado c/ AutoMapper (veja a classe WebApiMapperProfile).

                // Comportamento erro interno de servidor
                new InternalErrorExceptionMapping( 
                        exceptionType: typeof(Exception),
                        responseCode: HttpStatusCode.InternalServerError));

            // Obs.: Para o cenario de erro interno, o modelo de resposta
            // devera ser estatico (ver Otc.DomainBase.Exceptions.InternalError)
            // ---------------------

            services.AddTmdbAdapter(
                Configuration.SafeGet<TmdbAdapterConfiguration>());

            services.AddApplication
                (Configuration.SafeGet<ApplicationConfiguration>());
        }
    }
}
