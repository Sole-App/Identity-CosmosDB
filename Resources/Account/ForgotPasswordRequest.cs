using Newtonsoft.Json;
using System;

namespace Munizoft.Identity.Resources.Account
{
    public class ForgotPasswordRequest
    {
        [JsonProperty("username")]
        public String UserName { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}