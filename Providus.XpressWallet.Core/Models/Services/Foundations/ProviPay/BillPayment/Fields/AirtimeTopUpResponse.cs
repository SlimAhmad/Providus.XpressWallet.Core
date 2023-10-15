using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Fields
{
    internal class AirtimeTopUpResponse
    {
        [JsonProperty("bill_id")]
        public int BillId { get; set; }

        [JsonProperty("fee")]
        public double Fee { get; set; }

        [JsonProperty("field_id")]
        public int FieldId { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("validate")]
        public string Validate { get; set; }

        public class Field
        {
            [JsonProperty("call_tag")]
            public string CallTag { get; set; }

            [JsonProperty("field_type")]
            public string FieldType { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("list")]
            public List List { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("narration_order")]
            public string NarrationOrder { get; set; }
        }

        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class List
        {
            [JsonProperty("items")]
            public List<Item> Items { get; set; }

            [JsonProperty("list_type")]
            public string ListType { get; set; }
        }






    }
}
