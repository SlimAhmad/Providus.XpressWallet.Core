using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant
{
    public class MerchantKYCRequest
    {
        [JsonProperty("cac_pack")]
        public IFormFile CacPack { get; set; }

        [JsonProperty("directorsBVN")]
        public string DirectorsBVN { get; set; }

        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

    }
}
