using Munizoft.Identity.Infrastructure.Models;
using Munizoft.Identity.Resources.Auth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munizoft.Identity.Infrastructure.Services
{
    public interface IAuthService
    {
        /// <summary>
        ///     Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(LoginResponseResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> LoginAsync(LoginRequestResource request);

        /// <summary>
        ///     Logout
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(LogoutResponseResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> Logout(LogoutRequestResource request);
    }
}
