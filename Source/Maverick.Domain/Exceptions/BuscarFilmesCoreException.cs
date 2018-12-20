using Otc.DomainBase.Exceptions;

namespace Maverick.Domain.Exceptions
{
    public class BuscarFilmesCoreException : CoreException<BuscarFilmesCoreError>
    {
        public BuscarFilmesCoreException(BuscarFilmesCoreError buscarFilmesCoreError)
        {
            AddError(buscarFilmesCoreError);
        }
    }

    public class BuscarFilmesCoreError : CoreError
    {
        public static BuscarFilmesCoreError LimiteDeRequisicoesAtingido =>
            new BuscarFilmesCoreError("LimiteDeRequisicoesAtingido", "O limite de requisições ao provedor de filmes foi atingido, tente novamente mais tarde.");
        
        protected BuscarFilmesCoreError(string key, string message) : base(key, message)
        {
        }
    }
}
