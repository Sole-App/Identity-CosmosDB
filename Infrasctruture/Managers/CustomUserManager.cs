using Microsoft.AspNetCore.Identity;
using System;

namespace Munizoft.Identity.Infrastructure.Managers
{
    public class CustomUserManager<TUser> //: UserManager<TUser>
        //where TUser : Entities.User
    {
        /// <summary>
        ///     Persistence abstraction that the UserManager operates against
        /// </summary>
        //protected internal IUserStore<TUser> Store { get; set; }

        //public CustomUserManager(IUserStore<TUser> store)
        //    //: base(store)
        //{
        //    if (store == null)
        //    {
        //        throw new ArgumentNullException(nameof(store));
        //    }

        //    Store = store;

        //    //UserValidator = new UserValidator<TUser, Guid>(this);
        //    //PasswordValidator = new MinimumLengthValidator(6);
        //    //PasswordHasher = new PasswordHasher();
        //    //ClaimsIdentityFactory = new ClaimsIdentityFactory<TUser, Guid>();

        //    //this.EmailService = emailService;
        //}
    }
}
