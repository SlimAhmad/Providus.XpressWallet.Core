using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class TransfersServiceException : Xeption
    {
        public TransfersServiceException(Xeption innerException)
            : base(message: "Transfers service error occurred, contact support.",
                  innerException)
        { }

        public TransfersServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}