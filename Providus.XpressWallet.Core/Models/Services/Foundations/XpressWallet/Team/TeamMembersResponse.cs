using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team
{
    public class TeamMembersResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("approvalLimit")]
            public int ApprovalLimit { get; set; }
        }

     
           
        


    }
}
