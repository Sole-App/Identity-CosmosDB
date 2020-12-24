using Munizoft.Identity.Infrastructure.Models;
using Munizoft.Identity.Resources.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munizoft.Identity.Infrastructure.Services
{
    public interface IUserService
    {
        /// <summary>
        ///     Create User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(UserResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> CreateAsync(UserCreateRequestResource request);

        /// <summary>
        ///     List Users
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(IEnumerable<UserResource> Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> ListAsync();
    }
}
