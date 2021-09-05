using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoreAPIWithJWT.IdentityAuth
{
    public class UserRoles // testing
    {
        public static string Admin { get; } = "Admin";
        public static string User { get; } = "User";
    }
}
