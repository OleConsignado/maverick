using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maverick.TmdbAdapter.Clients
{
    /// <summary>
    /// Esta interface representa o cliente da API TMDb. 
    /// A sua implementacao eh gerada automaticamente com base nas decoracoes.
    /// A biblioteca Refit eh responsavel pela geracao do codigo
    /// (https://github.com/reactiveui/refit).
    /// </summary>
    internal interface ITmdbApi
    {
        [Get("/search/movie")]
        Task<TmdbSearchMoviesGetResult> SearchMovies(
            [Query] TmdbSearchMoviesGet tmdbSearchMoviesGet);

        [Get("/genre/movie/list")]
        Task<TMDBGendersGetResult> GetGenders(TMDBRequestBaseDTO dto);
    }
}
