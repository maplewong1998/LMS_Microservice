using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations.IdentityServer.UserDb
{
    public partial class MigrationWithSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53bed421-b6c4-4890-8a87-0366a97430ea", "fda52dae-e994-4d5d-a04a-293a185f564a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "User", "593a6a8e-9a06-4cf8-9fe4-128f662468cb", "ad03ab01-81b4-4b38-89df-5efa55fe488f", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "account_status", "address", "dob", "full_name" },
                values: new object[] { "27f8010f-4a41-410f-8373-a4a13d69fcf3", 0, "fafbde27-0e19-4b49-ac69-be17cdf826a3", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEKC89C+RJG6wqPsY6n4/OfGA0VIYpT50Q3G2qaTtwwiQwRzp96XvN9JFQSJg8HdrXw==", "0101010101", true, "399d6176-0470-4081-8ca8-d4a8b9ba5387", false, "admin", "active", "11, Jalan LP 8/1, Taman Equine", "05/05/1995", "Wong TS" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[] { 1, "role", "Administrator", "53bed421-b6c4-4890-8a87-0366a97430ea" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "email", "admin@email.com", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 2, "email_verified", "true", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 3, "address", "11, Jalan LP 8/1, Taman Equine", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 4, "name", "Wong TS", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 5, "family_name", "Wong", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 6, "given_name", "TS", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 7, "preferred_username", "admin", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 8, "birthdate", "05/05/1995", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 9, "account_status", "active", "27f8010f-4a41-410f-8373-a4a13d69fcf3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53bed421-b6c4-4890-8a87-0366a97430ea", "27f8010f-4a41-410f-8373-a4a13d69fcf3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53bed421-b6c4-4890-8a87-0366a97430ea", "27f8010f-4a41-410f-8373-a4a13d69fcf3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bed421-b6c4-4890-8a87-0366a97430ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27f8010f-4a41-410f-8373-a4a13d69fcf3");
        }
    }
}
