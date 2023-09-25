using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions
{
    internal class ExternalReverseBatchTransactionRequest
    {
        [JsonProperty("batchReference")]
        public string BatchReference { get; set; }
    }

}
