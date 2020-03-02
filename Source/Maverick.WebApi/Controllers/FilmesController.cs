using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Maverick.Domain.Models;
using Maverick.Domain.Services;
using Maverick.WebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otc.AspNetCore.ApiBoot;
using Otc.DomainBase.Exceptions;

namespace Maverick.WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class FilmesController : ApiController
    {
        private readonly IFilmesService filmesService;
        private readonly IMapper mapper;

        public FilmesController(IFilmesService filmesService, IMapper mapper)
        {
            this.filmesService = filmesService ??
                throw new ArgumentNullException(nameof(filmesService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Pesquisa por filmes.
        /// </summary>
        /// <param name="filmesGet">
        ///     Criterios de pesquisa na base de filmes.
        /// </param>
        /// <response code="200">Lista de resultados.</response>
        /// <response code="400">
        ///     Parametros incorretos ou limite de utilização excedido.
        /// </response>
        /// <response code="500">Erro interno.</response>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(FilmesGetResult), 200)]
        [ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        [ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> GetFilmesAsync(
            [FromQuery] FilmesGet filmesGet)
        {
            Pesquisa pesquisa = mapper.Map<FilmesGet, Pesquisa>(filmesGet);
            IEnumerable<Filme> filmes = await filmesService
                .ObterFilmesAsync(pesquisa);
            IEnumerable<FilmesGetResult> filmesGetResults =
                mapper.Map<IEnumerable<FilmesGetResult>>(filmes);

            return Ok(filmesGetResults);
        }
    }
}
