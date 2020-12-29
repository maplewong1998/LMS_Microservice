using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class RoleInfo
    {
        public const string adminRoleId = "53bed421-b6c4-4890-8a87-0366a97430ea";
        public const string adminRole = "Administrator";
        public const string userRoleId = "ad03ab01-81b4-4b38-89df-5efa55fe488f";
        public const string userRole = "User";

        public static IEnumerable<IdentityRole> roles
        {
            get
            {
                return new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Id = adminRoleId,
                        Name = adminRole,
                        NormalizedName = adminRole.ToUpper()
                    },
                    new IdentityRole
                    {
                        Id = userRole,
                        Name = userRoleId,
                        NormalizedName = userRole.ToUpper()
                    }
                };
            }
        }
    }
}
