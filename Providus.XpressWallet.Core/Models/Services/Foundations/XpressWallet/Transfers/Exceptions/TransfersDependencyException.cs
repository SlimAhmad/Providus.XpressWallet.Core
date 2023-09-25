using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class TransfersDependencyException : Xeption
    {
        public TransfersDependencyException(Xeption innerException)
            : base(message: "Transfers dependency error occurred, contact support.",
                  innerException)
        { }

        public TransfersDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}