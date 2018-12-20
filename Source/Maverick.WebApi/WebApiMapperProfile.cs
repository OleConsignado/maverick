using AutoMapper;
using Maverick.Domain.Models;
using Maverick.WebApi.Dtos;

namespace Maverick.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<Filme, FilmesGetResult>();
            CreateMap<FilmesGet, Pesquisa>();
        }
    }
}
