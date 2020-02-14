using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Maverick.Domain.Exceptions
{
    public abstract class CoreException : Exception
    {
        protected CoreException()
        {
        }

        protected CoreException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    public abstract class CoreException<T> : CoreException
    {
        private readonly List<T> errors = new List<T>();

        public IEnumerable<T> Errors => errors;

        public CoreException<T> Add(params T[] errors)
        {
            this.errors.AddRange(errors);

            return this;
        }

        protected CoreException(params T[] errors) : base()
        {
            Add(errors);
        }

        protected CoreException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
