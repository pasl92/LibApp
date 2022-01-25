using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApp.Data.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "HasNewsletterSubscribed", "MembershipTypeId", "Name" },
                values: new object[] { 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, (byte)1, "Jan Skoczek" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "HasNewsletterSubscribed", "MembershipTypeId", "Name" },
                values: new object[] { 2, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, (byte)1, "Robert Kubica" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "HasNewsletterSubscribed", "MembershipTypeId", "Name" },
                values: new object[] { 3, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, (byte)1, "Dawid Dzięcioł" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
