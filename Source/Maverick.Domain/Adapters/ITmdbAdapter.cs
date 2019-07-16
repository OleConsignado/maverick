﻿using Maverick.Domain.Exceptions;
using Maverick.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maverick.Domain.Adapters
{
    public interface ITmdbAdapter
    {
        /// <summary>
        /// Realiza pesquisa em filmes.
        /// </summary>
        /// <param name="pesquisa">Criterios de pesquisa.</param>
        /// <param name="idioma">Idioma da pesquisa/resultado</param>
        /// <returns>Lista dos filmes encontrados conforme criterio de pesquisa.</returns>
        /// <exception cref="BuscarFilmesCoreException" />
        Task<IEnumerable<Filme>> GetFilmesAsync(Pesquisa pesquisa, string idioma);
    }
}
