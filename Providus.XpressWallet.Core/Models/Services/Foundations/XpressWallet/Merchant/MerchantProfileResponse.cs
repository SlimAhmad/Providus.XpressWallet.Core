using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant
{
    public class MerchantProfileResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public DataResponse Data { get; set; }

        public class DataResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("bvn")]
            public object Bvn { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("callbackURL")]
            public string CallbackURL { get; set; }

            [JsonProperty("businessName")]
            public string BusinessName { get; set; }

            [JsonProperty("businessType")]
            public string BusinessType { get; set; }

            [JsonProperty("merchantType")]
            public string MerchantType { get; set; }

            [JsonProperty("review")]
            public string Review { get; set; }

            [JsonProperty("walletReservationCharge")]
            public int WalletReservationCharge { get; set; }

            [JsonProperty("bvnChargeV1")]
            public int BvnChargeV1 { get; set; }

            [JsonProperty("bvnVerificationCharge")]
            public int BvnVerificationCharge { get; set; }

            [JsonProperty("walletToWalletTransfer")]
            public int WalletToWalletTransfer { get; set; }

            [JsonProperty("airtimeCharge")]
            public int AirtimeCharge { get; set; }

            [JsonProperty("transferCharges")]
            public TransferCharges TransferCharges { get; set; }

            [JsonProperty("contractCode")]
            public object ContractCode { get; set; }

            [JsonProperty("secretKey")]
            public object SecretKey { get; set; }

            [JsonProperty("apiKey")]
            public object ApiKey { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("fundingRate")]
            public double FundingRate { get; set; }

            [JsonProperty("fundingRateMax")]
            public int FundingRateMax { get; set; }

            [JsonProperty("sandboxCallbackURL")]
            public string SandboxCallbackURL { get; set; }

            [JsonProperty("tier_1_daily_limit")]
            public int Tier1DailyLimit { get; set; }

            [JsonProperty("tier_2_daily_limit")]
            public int Tier2DailyLimit { get; set; }

            [JsonProperty("tier_3_daily_limit")]
            public int Tier3DailyLimit { get; set; }

            [JsonProperty("tier_1_min_balance")]
            public int Tier1MinBalance { get; set; }

            [JsonProperty("tier_2_min_balance")]
            public int Tier2MinBalance { get; set; }

            [JsonProperty("tier_3_min_balance")]
            public int Tier3MinBalance { get; set; }

            [JsonProperty("baseCustomerWalletCredit")]
            public int BaseCustomerWalletCredit { get; set; }

            [JsonProperty("canLogin")]
            public bool CanLogin { get; set; }

            [JsonProperty("sendEmail")]
            public bool SendEmail { get; set; }

            [JsonProperty("autoCardFunding")]
            public bool AutoCardFunding { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

       
           
        

        public class TransferCharges
        {
            [JsonProperty("max5000")]
            public int Max5000 { get; set; }

            [JsonProperty("max50000")]
            public int Max50000 { get; set; }

            [JsonProperty("min50000")]
            public int Min50000 { get; set; }
        }


    }
}
