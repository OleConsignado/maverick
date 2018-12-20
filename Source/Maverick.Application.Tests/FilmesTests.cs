using Maverick.Domain.Adapters;
using Maverick.Domain.Models;
using Maverick.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Otc.DomainBase.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Maverick.Application.Tests
{
    public class FilmesTests
    {
        private readonly ServiceProviderFactory serviceProviderFactory;

        public FilmesTests()
        {
            serviceProviderFactory = new ServiceProviderFactory(services =>
            {
                services.AddApplication(new ApplicationConfiguration());
            });
        }

        [Fact]
        public async Task Test_Pesquisa()
        {
            // Objeto que sera utilizado para retorno do Mock
            var expected = new List<Filme>()
                {
                    new Filme()
                    {
                        Id = 10447,
                        Descricao = "descricao_teste",
                        Nome = "nome_teste"
                    }
                };

            var tmdbAdapterMock = new Mock<ITmdbAdapter>();

            // Configura o Mock
            tmdbAdapterMock
                .Setup(m => m.GetFilmesAsync(It.IsAny<Pesquisa>(), "pt-BR"))
                .ReturnsAsync(expected);

            var serviceProvider = serviceProviderFactory.CreateServiceProviderWithMocks(tmdbAdapterMock);
            var filmesService = serviceProvider.GetService<IFilmesService>();

            var filmes = await filmesService.ObterFilmesAsync(new Pesquisa()
            {
                TermoPesquisa = "teste"
            });

            Assert.Contains(filmes, f => f.Id == expected.Single().Id);
        }

        [Fact]
        public async Task Test_ModelValidationException()
        {
            var tmdbAdapterMock = new Mock<ITmdbAdapter>();
            var serviceProvider = serviceProviderFactory.CreateServiceProviderWithMocks(tmdbAdapterMock);
            var filmesService = serviceProvider.GetService<IFilmesService>();

            await Assert.ThrowsAnyAsync<ModelValidationException>(async () =>
            {
                await filmesService.ObterFilmesAsync(new Pesquisa());
            });
        }
    }
}
