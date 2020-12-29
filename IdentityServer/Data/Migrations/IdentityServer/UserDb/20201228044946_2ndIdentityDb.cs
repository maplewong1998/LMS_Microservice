using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations.IdentityServer.UserDb
{
    public partial class _2ndIdentityDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-23er-90df-789o-0dusy6ct4elo");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "e78922fd-573b-4e3b-b721-2f9c84668825", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-23er-90df-789o-0dusy6ct4elo", "43a65f15-3d30-464d-8bbb-4ca6d741fd46", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "account_status", "address", "dob", "full_name" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "bc6821a3-1a90-4652-8281-389168acda96", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEIbY6tdg/3Lt2KCz0bTc5VCT6JWIc50KqxkWzImzU+iurI4Ko3eB+6WL5psbPPN3Uw==", "0101010101", true, "abc14f76-d38a-4196-95ca-483d2272c11c", false, "admin", "active", "15, Jalan LP 8/3, Taman Lestari Perdana", "05/24/1998", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });
        }
    }
}
