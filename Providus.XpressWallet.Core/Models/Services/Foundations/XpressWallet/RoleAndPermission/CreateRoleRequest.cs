using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission
{
    public class CreateRoleRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }

    }
}
