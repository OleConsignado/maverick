using Otc.ComponentModel.DataAnnotations;

namespace Maverick.Domain.Models
{
    public class Pesquisa
    {
        /// <summary>
        /// Termo a ser pesquisado.
        /// </summary>
        [Required(ErrorKey = "TermoPesquisaObrigatorio")]
        public string TermoPesquisa { get; set; }

        /// <summary>
        /// Ano de lançamento.
        /// </summary>
        public int? AnoLancamento { get; set; }
    }
}
