using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories
{
    internal class ExternalCategoriesResponse
    {
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("list_order")]
        public string ListOrder { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
