using Maverick.Domain.Adapters;
using Maverick.Domain.Models;
using Maverick.Domain.Services;
using Otc.Validations.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maverick.Application
{
    public class FilmesService : IFilmesService
    {
        private readonly ITmdbAdapter tmdbAdapter;
        private readonly ApplicationConfiguration configuration;

        public FilmesService(ITmdbAdapter tmdbAdapter, ApplicationConfiguration configuration)
        {
            this.tmdbAdapter = tmdbAdapter ?? throw new ArgumentNullException(nameof(tmdbAdapter));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<Filme>> ObterFilmesAsync(Pesquisa pesquisa)
        {
            ValidationHelper.ThrowValidationExceptionIfNotValid(pesquisa);

            return await tmdbAdapter.GetFilmesAsync(pesquisa, configuration.Idioma);
        }
    }
}
