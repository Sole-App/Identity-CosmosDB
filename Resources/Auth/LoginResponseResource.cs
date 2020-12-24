using Newtonsoft.Json;
using System;

namespace Munizoft.Identity.Resources.Auth
{
    public class LoginResponseResource
    {
        [JsonProperty("user_id")]
        public String UserId { get; set; }

        [JsonProperty("username")]
        public String Username { get; set; }

        [JsonIgnore]
        public String Password { get; set; }

        [JsonProperty("access_token")]
        public String AccessToken { get; set; }

        [JsonProperty("expiresIn")]
        public DateTime ExpiresIn { get; set; }
    }
}