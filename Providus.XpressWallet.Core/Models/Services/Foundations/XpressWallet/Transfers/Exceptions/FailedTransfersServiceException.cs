using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class FailedTransfersServiceException : Xeption
    {
        public FailedTransfersServiceException(Exception innerException)
            : base(message: "Failed transfer service error occurred, contact support.",
                  innerException)
        { }

        public FailedTransfersServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}