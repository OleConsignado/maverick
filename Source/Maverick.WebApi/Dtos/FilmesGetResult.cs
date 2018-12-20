using System;

namespace Maverick.WebApi.Dtos
{
    public class FilmesGetResult
    {
        /// <summary>
        /// Identificador do filme no The Moview Database.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome do filme.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descricao/Resumo do filme.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data de lancamento do filme.
        /// </summary>
        public DateTimeOffset DataLancamento { get; set; }
    }
}
