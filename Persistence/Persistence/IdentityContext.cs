using ElCamino.AspNetCore.Identity.CosmosDB;
using ElCamino.AspNetCore.Identity.CosmosDB.Model;

namespace Sole.Identity.CosmosDB.Core.Persistence
{
    public class IdentityContext : IdentityCloudContext
    {
        public IdentityContext(IdentityConfiguration config)
            : base(config)
        {
        }

    }
}
