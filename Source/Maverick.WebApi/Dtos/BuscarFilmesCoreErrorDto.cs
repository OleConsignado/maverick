using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maverick.WebApi.Dtos
{
    public enum BuscarFilmesCoreErrorDto
    {
        /// <summary>
        /// O limite de requisicoes por tempo foi atingido. O consumidor
        /// podera tentar efetuar novas requisicoes posteriormente.
        /// </summary>
        LimiteDeRequisicoesAtingido = 1,

        /// <summary>
        /// O usuario efetuou uma pesquisa com um termo nao permitido.
        /// </summary>
        TermoDePesquisaNaoPermitido = 2
    }
}
