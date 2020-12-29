using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class RoleClaimInfo
    {
        public const string claimType_Role = "role";
        public const string claimValue_Administrator = "Administrator";
        public const string claimValue_User = "User";

        public static IdentityRoleClaim<string> adminClaims
        {
            get
            {
                return new IdentityRoleClaim<string>
                {
                    Id = 1,
                    RoleId = RoleInfo.adminRoleId,
                    ClaimType = claimType_Role,
                    ClaimValue = claimValue_Administrator
                };
            }
        }
    }
}
