using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Constants
    {
        public static readonly string[] roles = { "Administrator", "User" };

        public const string RoleClaimType = "role";
        public const string AccountStatusClaimType = "account_status";
    }
}
