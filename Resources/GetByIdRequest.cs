﻿using Newtonsoft.Json;

namespace Munizoft.Identity.Resources
{
    public class GetByIdRequest<TKey>
    {
        [JsonProperty("id")]
        public TKey Id { get; set; }
    }
}