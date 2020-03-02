using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Maverick.Domain.Adapters;
using Maverick.Domain.Exceptions;
using Maverick.Domain.Models;
using Maverick.TmdbAdapter.Clients;
using Otc.Caching.Abstractions;
using Refit;

namespace Maverick.TmdbAdapter
{
    internal class TmdbAdapter : ITmdbAdapter
    {
        private readonly ITmdbApi tmdbApi;
        private readonly TmdbAdapterConfiguration tmdbAdapterConfiguration;
        private readonly ITypedCache typedCache;
        private readonly IMapper mapper;

        public TmdbAdapter(ITmdbApi tmdbApi,
            TmdbAdapterConfiguration tmdbAdapterConfiguration,
            ITypedCache typedCache,
            IMapper mapper)
        {
            this.tmdbApi = tmdbApi ??
                throw new ArgumentNullException(nameof(tmdbApi));

            this.tmdbAdapterConfiguration = tmdbAdapterConfiguration ??
                throw new ArgumentNullException(nameof(tmdbAdapterConfiguration));

            this.typedCache = typedCache ??
                throw new ArgumentNullException(nameof(typedCache));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Filme>> GetFilmesAsync(
            Pesquisa pesquisa, string idioma)
        {
            try
            {
                var cacheKey = $"filmes::{pesquisa.TermoPesquisa}::" +
                    $"{pesquisa.AnoLancamento}::{idioma}";

                if (!typedCache.TryGet(cacheKey,
                    out TmdbSearchMoviesGetResult tmdbSearchMoviesGetResult))
                {
                    var tmdbSearchMoviesGet =
                        mapper.Map<TmdbSearchMoviesGet>(pesquisa);

                    tmdbSearchMoviesGet.ApiKey =
                        tmdbAdapterConfiguration.TmdbApiKey;

                    tmdbSearchMoviesGet.Language = idioma;

                    tmdbSearchMoviesGetResult = await tmdbApi
                        .SearchMovies(tmdbSearchMoviesGet);

                    typedCache.Set(cacheKey, tmdbSearchMoviesGetResult,
                        TimeSpan
                        .FromSeconds(
                            tmdbAdapterConfiguration
                            .TempoDeCacheDaPesquisaEmSegundos));
                }

                return mapper
                    .Map<IEnumerable<Filme>>(tmdbSearchMoviesGetResult.Results);
            }
            catch (ApiException e)
            {
                switch (e.StatusCode)
                {
                    case (HttpStatusCode)429: // TooManyRequests
                        throw new BuscarFilmesCoreException(
                            BuscarFilmesCoreError.LimiteDeRequisicoesAtingido);
                }

                // Qualquer outro codigo de retorno esta sendo considerado como
                // uma situacao nao prevista.  A excecao sera relancada e caso
                // nao tratada, acarretara em um erro interno. 
                // Obs.: Deixar essa excecao sem tratamento, a principio nao eh
                // errado, pois eh uma condicao nao prevista, ou seja,
                // desconhecida. Como este projeto implementa um ponto central
                // de tratamento de erros (por meio das bibliotecas
                // Otc.ExceptionHandler e Otc.Mvc.Filters) este erro sera
                // devidamente registrado (logs) e um identificador do registro
                // sera fornecido na resposta. Note que em ambientes de
                // desenvolvimento, (variavel de ambiente ASPNETCORE_ENVIRONMENT
                // definida como Development) a excecao sera exposta na resposta,
                // no entanto, em ambientes produtivos,
                // apenas o identificador do log do erro sera fornecido.
                throw;
            }
        }
    }
}
