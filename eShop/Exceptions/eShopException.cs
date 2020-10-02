using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Exceptions
{
    public abstract class eShopException : Exception
    {
        public string Code { get; }

        protected eShopException()
        {
        }

        protected eShopException(string code)
        {
            Code = code;
        }

        protected eShopException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected eShopException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected eShopException(Exception innerException, string message, params object[] args) : this(innerException, string.Empty, message, args)
        {
        }

        protected eShopException(Exception innerException, string code, string message, params object[] args) : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
