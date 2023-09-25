using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class FailedServerTransfersException : Xeption
    {
        public FailedServerTransfersException(Exception innerException)
            : base(message: "Failed transfer server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerTransfersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}