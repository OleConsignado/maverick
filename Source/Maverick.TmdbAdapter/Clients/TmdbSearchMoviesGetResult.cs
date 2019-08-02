using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maverick.TmdbAdapter.Clients
{
    /// <summary>
    /// Modelo do retorno para a rota /search/movie do TMDb API
    /// (https://developers.themoviedb.org/3/search/search-movies)
    /// <para>
    /// Este modelo representa exatamente o retorno da rota search/movie API
    /// TMDb e eh o retorno do metodo <see cref="ITmdbApi.SearchMovies"/>.
    /// O Refit implementa a deserializacao do resultado da chamada para esta
    /// estrutura.
    /// </para>
    /// <para>    
    /// Note que esta classe eh interna ao Adaptador, 
    /// os dados serao mapeados para <see cref="Domain.Models.Filme" />
    /// para serem expostos.
    /// O mapeamento eh feito em <see cref="TmdbAdapter.GetFilmesAsync"/>.
    /// </para>
    /// </summary>
    internal class TmdbSearchMoviesGetResult
    {
        internal class ResultItem
        {
            public long Id { get; set; }

            public string Title { get; set; }

            public string Overview { get; set; }

            [JsonProperty(PropertyName = "release_date")]
            public DateTimeOffset? ReleaseDate { get; set; }
        }

        public IEnumerable<ResultItem> Results { get; set; }
    }
}
