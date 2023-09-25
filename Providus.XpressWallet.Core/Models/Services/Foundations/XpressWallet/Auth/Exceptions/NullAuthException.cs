using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public partial class NullAuthException : Xeption
    {
        public NullAuthException()
            : base(message: "Auth is null.")
        { }

        public NullAuthException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
