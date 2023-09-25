using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class ExcessiveCallTransfersException : Xeption
    {
        public ExcessiveCallTransfersException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallTransfersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}