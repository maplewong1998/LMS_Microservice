using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations.IdentityServer.UserDb
{
    public partial class _5thM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bed421-b6c4-4890-8a87-0366a97430ea",
                column: "ConcurrencyStamp",
                value: "a9c833dc-e7d3-4535-97a0-f6daf5fc6dc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad03ab01-81b4-4b38-89df-5efa55fe488f",
                column: "ConcurrencyStamp",
                value: "dcbd76f6-f290-4c14-b1b5-0f6ab029ff22");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27f8010f-4a41-410f-8373-a4a13d69fcf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46a8f37d-0824-44fb-a3b4-81c547e4a743", "AQAAAAEAACcQAAAAEJhWvJ8n0n9axcGzE0Apz1yOGM7IXVke1TYDZxFv2mJNooh9LU1XqUNAxG4ZQMfGnw==", "16249751-086b-4424-9b49-80365e323025" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bed421-b6c4-4890-8a87-0366a97430ea",
                column: "ConcurrencyStamp",
                value: "496aa692-5347-45f4-bb3c-49f405c23a4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad03ab01-81b4-4b38-89df-5efa55fe488f",
                column: "ConcurrencyStamp",
                value: "17ba7c6f-470e-444e-b485-06ac2abc1dc0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27f8010f-4a41-410f-8373-a4a13d69fcf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6c33cb1-9205-44aa-8de6-5af536529691", "AQAAAAEAACcQAAAAENrhRBqlGg+cDgiT0gavyB1UJUm57UJYnlycSGkET06lAjfdvKPGVHXBYlLJh8N+Ug==", "4546c7ba-377b-40f1-804c-c59fea81abf6" });
        }
    }
}
