using ElCamino.AspNetCore.Identity.CosmosDB.Model;
using System;
using System.Collections.Generic;

namespace Munizoft.Identity.Entities
{
    public class User : IdentityUser<String>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public ICollection<Attribute> Attributes { get; set; }

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public User(String email)
            : this()
        {
            this.UserName = email;
            this.Email = email;
            this.NormalizedEmail = email.ToUpper();
            this.NormalizedUserName = email.ToUpper();
        }

        public User(String email, String username)
            : this()
        {
            this.UserName = username;
            this.Email = email;
            this.NormalizedEmail = email.ToUpper();
            this.NormalizedUserName = username.ToUpper();
        }
    }
}