using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team
{
    public class InviteTeamMembersRequest
    {
        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("approvalLimit")]
        public int ApprovalLimit { get; set; }

    }
}
