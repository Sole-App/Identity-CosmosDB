using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Munizoft.Identity.Infrastructure.Services;
using Munizoft.Identity.Resources.Role;
using System.Threading.Tasks;

namespace Sole.Identity.CosmosDB.Controllers
{
    public class RolesController : BaseController<RolesController>
    {
        private readonly IRoleService _roleService;

        public RolesController(
            ILogger<RolesController> logger,
            IRoleService roleService
            )
            : base(logger)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _roleService.ListAsync();

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RoleCreateRequestResource request)
        {
            var result = await _roleService.CreateAsync(request);

            return Ok(result.Data);
        }
    }
}