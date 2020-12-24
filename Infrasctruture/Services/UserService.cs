using AutoMapper;
using ElCamino.AspNetCore.Identity.CosmosDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Munizoft.Identity.Entities;
using Munizoft.Identity.Infrastructure.Extensions;
using Munizoft.Identity.Infrastructure.Models;
using Munizoft.Identity.Resources.User;
using Sole.Identity.CosmosDB.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munizoft.Identity.Infrastructure.Services
{
    public class UserService : BaseService<UserService>, IUserService
    {
        private readonly UserStore<User, IdentityContext> _userStore;

        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            IOptions<Models.IdentityOptions> options,
            IdentityContext context)
            : base(logger, mapper, options)
        {
            _userStore = new UserStore<User, IdentityContext>(context, new IdentityErrorDescriber());
        }

        /// <summary>
        ///     Create User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(UserResource Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> CreateAsync(UserCreateRequestResource request)
        {
            try
            {
                var user = _mapper.Map<UserCreateRequestResource, User>(request);

                user.Id = Guid.NewGuid().ToString();

                var result = await _userStore.CreateAsync(user);

                if (request.Roles.Any())
                {
                    foreach (var role in request.Roles)
                    {
                        await _userStore.AddToRoleAsync(user, role.ToUpper());
                    }
                }

                if (result.Succeeded)
                {
                    var resource = _mapper.Map<User, UserResource>(user);

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
        ///     List Users
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(IEnumerable<UserResource> Data, Boolean Succeeded, IEnumerable<ServiceError> Errors)> ListAsync()
        {
            try
            {
                var users = _userStore.Users.ToList();

                var resource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

                return (resource, true, null);
            }
            catch (Exception ex)
            {
                return (null, false, ex.ToServiceError());
            }
        }
    }
}