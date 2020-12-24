using AutoMapper;
using ElCamino.AspNetCore.Identity.CosmosDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Munizoft.Identity.Entities;
using Munizoft.Identity.Infrastructure.Extensions;
using Munizoft.Identity.Infrastructure.Models;
using Munizoft.Identity.Resources.Role;
using Sole.Identity.CosmosDB.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munizoft.Identity.Infrastructure.Services
{
    public class RoleService : BaseService<RoleService>, IRoleService
    {
        private readonly RoleStore<Role, IdentityContext> _roleStore;

        public RoleService(
            ILogger<RoleService> logger,
            IMapper mapper,
            IOptions<Models.IdentityOptions> options,
            IdentityContext context)
            : base(logger, mapper, options)
        {
            _roleStore = new RoleStore<Role, IdentityContext>(context, new IdentityErrorDescriber());
        }

        /// <summary>
        ///     Create Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(RoleResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> CreateAsync(RoleCreateRequestResource request)
        {
            try
            {
                var role = _mapper.Map<RoleCreateRequestResource, Role>(request);

                var result = await _roleStore.CreateAsync(role);

                if (result.Succeeded)
                {
                    var resource = _mapper.Map<Role, RoleResource>(role);

                    return (resource, true, null);
                }

                return (null, false, result.Errors.ToServiceError());
            }
            catch (Exception ex)
            {
                return (null, false, ex.ToServiceError());
            }
        }

        /// <summary>
        ///     List Roles
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(IEnumerable<RoleResource> Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> ListAsync()
        {
            try
            {
                //var roles =  _roleStore.;
                var roles = _roleStore.Roles.ToList();

                var resource = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roles);

                return (resource, true, null);
            }
            catch (Exception ex)
            {
                return (null, false, ex.ToServiceError());
            }
        }
    }
}
