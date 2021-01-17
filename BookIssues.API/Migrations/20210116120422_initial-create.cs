using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookIssues.API.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookIssues",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    member_email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    book_id = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    issue_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    issue_status = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIssues", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "BookIssues",
                columns: new[] { "id", "book_id", "due_date", "issue_date", "issue_status", "member_email" },
                values: new object[] { "1", "978-0062316097", new DateTime(2016, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Returned", "admin@email.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookIssues");
        }
    }
}
