using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public partial class NullTransfersException : Xeption
    {
        public NullTransfersException()
            : base(message: "Transfers is null.")
        { }

        public NullTransfersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
