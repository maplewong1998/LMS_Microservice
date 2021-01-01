using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations.IdentityServer.UserDb
{
    public partial class _4thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bed421-b6c4-4890-8a87-0366a97430ea",
                column: "ConcurrencyStamp",
                value: "496aa692-5347-45f4-bb3c-49f405c23a4c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad03ab01-81b4-4b38-89df-5efa55fe488f", "17ba7c6f-470e-444e-b485-06ac2abc1dc0", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "name", "Wong TS" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "account_status", "active" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "userId", "27f8010f-4a41-410f-8373-a4a13d69fcf3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27f8010f-4a41-410f-8373-a4a13d69fcf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6c33cb1-9205-44aa-8de6-5af536529691", "AQAAAAEAACcQAAAAENrhRBqlGg+cDgiT0gavyB1UJUm57UJYnlycSGkET06lAjfdvKPGVHXBYlLJh8N+Ug==", "4546c7ba-377b-40f1-804c-c59fea81abf6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad03ab01-81b4-4b38-89df-5efa55fe488f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bed421-b6c4-4890-8a87-0366a97430ea",
                column: "ConcurrencyStamp",
                value: "fda52dae-e994-4d5d-a04a-293a185f564a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "User", "593a6a8e-9a06-4cf8-9fe4-128f662468cb", "ad03ab01-81b4-4b38-89df-5efa55fe488f", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "email_verified", "true" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "address", "11, Jalan LP 8/1, Taman Equine" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "name", "Wong TS" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 5, "family_name", "Wong", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 6, "given_name", "TS", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 7, "preferred_username", "admin", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 8, "birthdate", "05/05/1995", "27f8010f-4a41-410f-8373-a4a13d69fcf3" },
                    { 9, "account_status", "active", "27f8010f-4a41-410f-8373-a4a13d69fcf3" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27f8010f-4a41-410f-8373-a4a13d69fcf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fafbde27-0e19-4b49-ac69-be17cdf826a3", "AQAAAAEAACcQAAAAEKC89C+RJG6wqPsY6n4/OfGA0VIYpT50Q3G2qaTtwwiQwRzp96XvN9JFQSJg8HdrXw==", "399d6176-0470-4081-8ca8-d4a8b9ba5387" });
        }
    }
}
