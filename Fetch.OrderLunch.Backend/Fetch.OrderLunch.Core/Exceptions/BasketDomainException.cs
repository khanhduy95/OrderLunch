using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Exceptions
{
    public class BasketDomainException : Exception
    {
        public BasketDomainException()
        {
        }
        public BasketDomainException(string message) : base(message)
        {
        }
        public BasketDomainException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
