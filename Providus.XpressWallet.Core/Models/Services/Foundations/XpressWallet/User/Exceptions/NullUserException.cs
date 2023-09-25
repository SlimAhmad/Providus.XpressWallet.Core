using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public partial class NullUserException : Xeption
    {
        public NullUserException()
            : base(message: "User is null.")
        { }

        public NullUserException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
