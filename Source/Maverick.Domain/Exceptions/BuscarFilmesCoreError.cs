namespace Maverick.Domain.Exceptions
{
    public enum BuscarFilmesCoreError
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