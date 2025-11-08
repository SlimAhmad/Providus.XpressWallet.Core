using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class UpgradeCustomerWalletRequest
    {
        [JsonProperty("tier")]
        public WalletTier Tier { get; set; }
        public string CustomerId { get; set; }
    }

    public enum WalletTier
    {
        TIER_1,
        TIER_2,
        TIER_3
    }
}
