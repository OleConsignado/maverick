using Otc.DomainBase.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Maverick.Domain.Exceptions
{
    [Serializable]
    public class BuscarFilmesCoreException : CoreException<BuscarFilmesCoreError>
    {
        public BuscarFilmesCoreException(BuscarFilmesCoreError buscarFilmesCoreError)
        {
            AddError(buscarFilmesCoreError);
        }

        protected BuscarFilmesCoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Key => "BuscarFilmesCoreException";
    }
}
