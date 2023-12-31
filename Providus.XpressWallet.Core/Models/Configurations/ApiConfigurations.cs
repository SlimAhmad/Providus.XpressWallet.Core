﻿namespace Providus.XpressWallet.Core.Models.Configurations
{
    public class ApiConfigurations
    {
        public string ApiUrl { get; set; } = "https://payment.xpress-wallet.com/api/v1/";
        public string ApiKey { get; set; }
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

    }
}
