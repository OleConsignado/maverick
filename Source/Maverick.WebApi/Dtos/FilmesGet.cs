using Otc.ComponentModel.DataAnnotations;

namespace Maverick.WebApi.Dtos
{
    public class FilmesGet
    {
        /// <summary>
        /// Termo a ser pesquisado.
        /// </summary>
        public string TermoPesquisa { get; set; }

        /// <summary>
        /// Ano de lançamento.
        /// </summary>
        public int? AnoLancamento { get; set; }
    }
}
