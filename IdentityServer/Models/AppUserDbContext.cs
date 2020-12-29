using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        public AppUserDbContext(DbContextOptions<AppUserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<AppUser>().HasData(
                    new AppUser()
                    {
                        Id = AdminAccountInfo.adminId,
                        UserName = AdminAccountInfo.adminUserName,
                        Email = AdminAccountInfo.adminEmail,
                        full_name = AdminAccountInfo.adminName,
                        dob = AdminAccountInfo.adminDob,
                        address = AdminAccountInfo.adminAddress,
                        account_status = AdminAccountInfo.adminAccountStatus,
                        PhoneNumber = AdminAccountInfo.adminPhoneNumber,
                        NormalizedUserName = AdminAccountInfo.adminUserName.ToUpper(),
                        NormalizedEmail = AdminAccountInfo.adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, AdminAccountInfo.adminPassword)
                    }
                );

            builder.Entity<IdentityRole>().HasData(RoleInfo.roles);

            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = RoleInfo.adminRoleId,
                        UserId = AdminAccountInfo.adminId
                    }
                );

            builder.Entity<IdentityUserClaim<string>>().HasData(AdminAccountClaimInfo.claims);

            builder.Entity<IdentityRoleClaim<string>>().HasData(RoleClaimInfo.adminClaims);
        }
    }
}
