using ElCamino.AspNetCore.Identity.CosmosDB.Model;
using System;

namespace Munizoft.Identity.Entities
{
    public class Role : IdentityRole<String>
    {
        public Role()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
