using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Exceptions
{
    public class OrderingDomainException : Exception
    {
        public OrderingDomainException()
        { }

        public OrderingDomainException(string message)
            : base(message)
        { }

        public OrderingDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
