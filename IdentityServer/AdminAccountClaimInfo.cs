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
                        ClaimType = JwtClaimTypes.EmailVerified,
                        ClaimValue = "true"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 3,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.Address,
                        ClaimValue = AdminAccountInfo.adminAddress
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 4,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.Name,
                        ClaimValue = AdminAccountInfo.adminName
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 5,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.FamilyName,
                        ClaimValue = AdminAccountInfo.adminFamilyName
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 6,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.GivenName,
                        ClaimValue = AdminAccountInfo.adminGivenName
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 7,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.PreferredUserName,
                        ClaimValue = AdminAccountInfo.adminUserName
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 8,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = JwtClaimTypes.BirthDate,
                        ClaimValue = AdminAccountInfo.adminDob
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 9,
                        UserId = AdminAccountInfo.adminId,
                        ClaimType = Constants.AccountStatusClaimType,
                        ClaimValue = AdminAccountInfo.adminAccountStatus
                    }
                };
            }
        }
    }
}
