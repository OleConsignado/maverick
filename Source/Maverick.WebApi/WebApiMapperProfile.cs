using AutoMapper;
using Maverick.Domain.Models;
using Maverick.WebApi.Dtos;

namespace Maverick.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<FilmesGet, Pesquisa>();
        }
    }
}
