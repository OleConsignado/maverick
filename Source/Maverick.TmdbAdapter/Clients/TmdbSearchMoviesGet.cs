using Refit;

namespace Maverick.TmdbAdapter.Clients
{
    /// <summary>
    /// Modelo do entrada para a rota /search/movie do TMDb API
    /// (https://developers.themoviedb.org/3/search/search-movies)
    /// <para>
    /// Este modelo representa exatamente os parametros para requisicoes na
    /// rota search/movie API TMDb e
    /// eh utilizado como parametro de entrada para o metodo
    /// <see cref="ITmdbApi.SearchMovies"/>.
    /// </para>
    /// <para>    
    /// Note que esta classe eh interna ao Adaptador, 
    /// os dados serao mapeados a partir de <see cref="Domain.Models.Pesquisa" />.
    /// O mapeamento eh feito em <see cref="TmdbAdapter.GetFilmesAsync"/>.
    /// </para>
    /// </summary>
    internal class TmdbSearchMoviesGet
    {
        [AliasAs("query")]
        public string Query { get; set; }
        [AliasAs("api_key")]
        public string ApiKey { get; set; }
        [AliasAs("language")]
        public string Language { get; set; }
        [AliasAs("year")]
        public int? Year { get; set; }
    }
}
