using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions
{
    public class NotFoundTransfersException : Xeption
    {
        public NotFoundTransfersException(Exception innerException)
            : base(message: "Not found transfers error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundTransfersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}