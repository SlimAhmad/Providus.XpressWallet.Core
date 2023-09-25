using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class InvalidConfigurationTransfersException : Xeption
    {
        public InvalidConfigurationTransfersException(Exception innerException)
            : base(message: "Invalid transfers configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationTransfersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}