using Newtonsoft.Json;
using System;

namespace Munizoft.Identity.Resources.Auth
{
    public class LogoutRequestResource
    {
        [JsonProperty("user_id")]
        public String UserId { get; set; }

        public LogoutRequestResource(String userId)
        {
            UserId = userId;
        }
    }
}