using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class UnauthorizedTransfersException : Xeption
    {
        public UnauthorizedTransfersException(Exception innerException)
            : base(message: "Unauthorized transfers request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedTransfersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}