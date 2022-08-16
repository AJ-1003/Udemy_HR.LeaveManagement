using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    public partial class SeedLeaveTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("44879e15-c0d4-4db2-b065-5a564483ffee"), "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5070), 32, "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5071), "Sick" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("56f376eb-2470-4b11-b69a-e8a9320777ef"), "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5049), 10, "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5056), "Annual" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("44879e15-c0d4-4db2-b065-5a564483ffee"));

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("56f376eb-2470-4b11-b69a-e8a9320777ef"));
        }
    }
}
