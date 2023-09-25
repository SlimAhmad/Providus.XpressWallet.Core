using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public partial class NullCardException : Xeption
    {
        public NullCardException()
            : base(message: "Card is null.")
        { }

        public NullCardException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
