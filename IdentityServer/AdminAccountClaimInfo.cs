using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class AdminAccountClaimInfo
    {
        public static IEnumerable<IdentityUserClaim<string>> claims
        {
            get
            {
                return new List<IdentityUserClaim<string>>
                {
                    new IdentityUserClaim<string>
                    {
                        Id = 1,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.Email,
                        ClaimValue = AdminAccountInfo.adminEmail
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 2,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.Name,
                        ClaimValue = AdminAccountInfo.adminName
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 3,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = Constants.AccountStatusClaimType,
                        ClaimValue = AdminAccountInfo.adminAccountStatus
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 4,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = Constants.UsernameClaimType,
                        ClaimValue = AdminAccountInfo.adminUserName
                    }
                };
            }
        }
    }
}
