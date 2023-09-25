using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public partial class NullMerchantException : Xeption
    {
        public NullMerchantException()
            : base(message: "Merchant is null.")
        { }

        public NullMerchantException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
