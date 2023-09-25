using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class InvalidTransfersException : Xeption
    {
        public InvalidTransfersException()
            : base(message: "Invalid transfers error occurred, fix errors and try again.")
        { }

        public InvalidTransfersException(Exception innerException)
            : base(message: "Invalid transfers error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidTransfersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}