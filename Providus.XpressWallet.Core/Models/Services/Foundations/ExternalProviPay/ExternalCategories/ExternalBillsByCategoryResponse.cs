using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalCategories
{
    internal class ExternalBillsByCategoryResponse
    {
        [JsonProperty("bill_id")]
        public int BillId { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("list_order")]
        public string ListOrder { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("source_id")]
        public string SourceId { get; set; }
    }
}
