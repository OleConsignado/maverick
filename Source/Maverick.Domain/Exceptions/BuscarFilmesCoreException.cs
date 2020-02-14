using System;
using System.Runtime.Serialization;

namespace Maverick.Domain.Exceptions
{
    [Serializable]
    public class BuscarFilmesCoreException : CoreException<BuscarFilmesCoreError>
    {
        public BuscarFilmesCoreException(params BuscarFilmesCoreError[] errors)
            : base(errors)
        {
        }

        protected BuscarFilmesCoreException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
