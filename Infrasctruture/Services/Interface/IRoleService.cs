using Munizoft.Identity.Infrastructure.Models;
using Munizoft.Identity.Resources.Role;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munizoft.Identity.Infrastructure.Services
{
    public interface IRoleService
    {
        /// <summary>
        ///     Create Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(RoleResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> CreateAsync(RoleCreateRequestResource request);

        /// <summary>
        ///     List Roles
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(IEnumerable<RoleResource> Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> ListAsync();
    }
}
