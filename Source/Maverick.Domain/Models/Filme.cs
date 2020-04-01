using System;
using System.Collections.Generic;

namespace Maverick.Domain.Models
{
    public class Filme
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

        /// <summary>
        /// Lista de generos atribuidos ao filme
        /// </summary>
        public List<string> Generos { get; set; }
    }
}
