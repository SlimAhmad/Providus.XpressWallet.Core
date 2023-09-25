using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet
{
    internal class ExternalFundMerchantSandBoxWalletRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
