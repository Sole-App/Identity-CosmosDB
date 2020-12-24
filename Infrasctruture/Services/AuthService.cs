using AutoMapper;
using ElCamino.AspNetCore.Identity.CosmosDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Munizoft.Identity.Entities;
using Munizoft.Identity.Infrastructure.Extensions;
using Munizoft.Identity.Infrastructure.Helpers;
using Munizoft.Identity.Infrastructure.Models;
using Munizoft.Identity.Resources.Auth;
using Munizoft.Identity.Validations;
using Munizoft.Identity.Validations.Extensions;
using Sole.Identity.CosmosDB.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munizoft.Identity.Infrastructure.Services
{
    public class AuthService : BaseService<AuthService>, IAuthService
    {
        private readonly UserStore<User, IdentityContext> _userStore;

        public AuthService(
            ILogger<AuthService> logger,
            IMapper mapper,
            IOptions<Models.IdentityOptions> options,
            IdentityContext context)
            : base(logger, mapper, options)
        {
            _userStore = new UserStore<User, IdentityContext>(context, new IdentityErrorDescriber());
        }

        /// <summary>
        ///     Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(LoginResponseResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> LoginAsync(LoginRequestResource request)
        {
            try
            {
                //if (!request.Validate<LoginRequestValidator, LoginRequest>().IsValid)
                //{
                //    var validations = request.Validate<LoginRequestValidator, LoginRequest>();
                //    return ServiceResult<LoginResponse>.Failed(validations.ToArray());
                //}

                //var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

                //if (result.Succeeded)
                //{
                //    var user = this._userManager.Users.SingleOrDefault(r => r.UserName == request.Username);

                //    var userCanLogin = await checkIfUsercanLogin(user, request.Url.AbsoluteUri);

                //    if (!userCanLogin.Succeeded)
                //    {
                //        return userCanLogin;
                //    }

                //    var roles = await _userManager.GetRolesAsync(user);

                //    var loginResponse = await JwtHelpers.GenerateToken(this._configuration, user, roles.FirstOrDefault());

                //    var userLoginHistory = this._mapper.Map<LoginRequest, UserLoginHistory>(request);
                //    userLoginHistory.LogInDateUtc = DateTime.UtcNow;
                //    userLoginHistory.UserId = user.Id;

                //    this._unitOfWork.UserLoginHistoryRepository.Add(userLoginHistory);
                //    var id = await _unitOfWork.SaveChangesAsync();

                //    return ServiceResult<LoginResponse>.OK(loginResponse);
                //}
                //else
                //{
                //    var user = await this._userManager.FindByNameAsync(request.Username);

                //    if (user != null) // Increase attempt login
                //    {
                //        var passwordValid = await this._userManager.CheckPasswordAsync(user, request.Password);

                //        if (!passwordValid)
                //        {
                //            await this._userManager.AccessFailedAsync(user);

                //            if (user.AccessFailedCount == this._configuration.GetUserLockoutValue())
                //            {
                //                await SendUserLockout(request.Url.AbsoluteUri, user);
                //            }
                //        }
                //    }

                //    var userCanLogin = await checkIfUsercanLogin(user, request.Url.AbsoluteUri);

                //    if (!userCanLogin.Succeeded)
                //    {
                //        return userCanLogin;
                //    }
                //}

                //return ServiceResult<LoginResponse>.Failed(MessagesHelpers.USER_INCORRECT);

                return (null, true, null);
            }
            catch (Exception ex)
            {
                return (null, false, ex.ToServiceError());
            }
        }

        /// <summary>
        ///     Logout
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(LogoutResponseResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> Logout(LogoutRequestResource request)
        {
            try
            {
                //if (!request.Validate<LogoutRequestValidator, LogoutRequestResource>().IsValid)
                //{
                //    var validations = request.Validate<LogoutRequestValidator, LogoutRequestResource>();
                //    return (null, false, validations.ToServiceError());
                //}

                var user = await _userStore.FindByIdAsync(request.UserId.ToString());

                if (user == null)
                {
                    return (null, false, new List<ServiceError> { new ServiceError(MessagesHelpers.USER_NOT_FOUND) });
                }

                //var lastLogin = this._unitOfWork.UserLoginHistoryRepository.Find(x => x.UserId == user.Id && x.LogOutDateUtc == null).OrderBy(o => o.LogInDateUtc).FirstOrDefault();

                //lastLogin.LogOutDateUtc = DateTime.UtcNow;

                return (null, true, null);
            }
            catch (Exception ex)
            {
                return (null, false, ex.ToServiceError());
            }
        }

        private async Task<(Boolean Succeeded, String Error)> checkIfUsercanLogin(Entities.User user, String url)
        {
            if (user == null)
            {
                return (false, MessagesHelpers.USER_NOT_FOUND);
            }

            //if (!user.Active)
            //{
            //    return (false, MessagesHelpers.USER_INACTIVE);
            //}

            //if (await _signInManager.IsLockedOut(user))
            //{
            //    await SendUserLockout(url, user);

            //    return (false, MessagesHelpers.USER_LOCKEDOUT);
            //}

            //if (!await _signInManager.HasSetUpPassword(user))
            //{
            //    return (false, MessagesHelpers.USER_PASSWORD_NOT_SETUP);
            //}

            //if (!await _signInManager.HasEmailConfirmed(user))
            //{
            //    return (false, MessagesHelpers.USER_NOT_CONFIRMED);
            //}

            return (true, null);
        }
    }
}