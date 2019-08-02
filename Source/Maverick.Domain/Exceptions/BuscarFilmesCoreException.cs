using Otc.DomainBase.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Maverick.Domain.Exceptions
{
    [Serializable]
    public class BuscarFilmesCoreException : CoreException<BuscarFilmesCoreError>
    {
        public BuscarFilmesCoreException(
            BuscarFilmesCoreError buscarFilmesCoreError)
        {
            AddError(buscarFilmesCoreError);
        }

        protected BuscarFilmesCoreException(SerializationInfo info, 
            StreamingContext context) 
            : base(info, context)
        {
        }

        public override string Key => "BuscarFilmesCoreException";
    }

    public class BuscarFilmesCoreError : CoreError
    {
        public static BuscarFilmesCoreError LimiteDeRequisicoesAtingido =>
            new BuscarFilmesCoreError("LimiteDeRequisicoesAtingido", 
                "O limite de requisições ao provedor de filmes foi atingido, " +
                "tente novamente mais tarde.");
        
        protected BuscarFilmesCoreError(string key, string message) 
            : base(key, message)
        {
        }
    }
}
