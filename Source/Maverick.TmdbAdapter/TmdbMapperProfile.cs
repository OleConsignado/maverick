using AutoMapper;
using Maverick.Domain.Models;
using Maverick.TmdbAdapter.Clients;

namespace Maverick.TmdbAdapter
{
    public class TmdbMapperProfile : Profile
    {
        public TmdbMapperProfile()
        {
            CreateMap<TmdbSearchMoviesGetResult.ResultItem, Filme>()
                // Mapeia a propriedade TmdbMovieResult.Overview para
                // Filme.Descricao.
                .ForMember(destino => destino.Descricao,
                    opt => opt.MapFrom(origem => origem.Overview))

                // TmdbMovieResult.Title -> Filme.Nome
                .ForMember(destino => destino.Nome,
                    opt => opt.MapFrom(origem => origem.Title))

                // TmdbMovieResult.ReleaseDate -> Filme.DataLancamento
                .ForMember(destino => destino.DataLancamento,
                    opt => opt.MapFrom(origem => origem.ReleaseDate));

            CreateMap<Pesquisa, TmdbSearchMoviesGet>()
                // Pesquisa.TermoPesquisa -> TmdbSearchMoviesGet.Query
                .ForMember(destino => destino.Query,
                    opt => opt.MapFrom(origem => origem.TermoPesquisa))

                // Pesquisa.AnoLancamento -> TmdbSearchMoviesGet.Year
                .ForMember(destino => destino.Year,
                    opt => opt.MapFrom(origem => origem.AnoLancamento));
        }
    }
}
