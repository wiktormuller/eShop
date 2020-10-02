using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Exceptions
{
    public class DomainException : eShopException
    {
        public DomainException()
        {
        }

        public DomainException(string code) : base(code)
        {
        }

        public DomainException(string message, params object[] args) : base(string.Empty, message, args)
        {
        }

        public DomainException(string code, string message, params object[] args) : base(null, code, message, args)
        {
        }

        public DomainException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args)
        {
        }

        public DomainException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }
    }
}
