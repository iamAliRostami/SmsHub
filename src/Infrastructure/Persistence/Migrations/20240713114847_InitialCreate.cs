using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmsHub.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Date", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 13, 15, 18, 45, 977, DateTimeKind.Local).AddTicks(1107), null, null, "John Egbert Live" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"));
        }
    }
}
