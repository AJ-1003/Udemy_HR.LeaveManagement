using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    public partial class AddedEmployeeIdToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("44879e15-c0d4-4db2-b065-5a564483ffee"));

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("56f376eb-2470-4b11-b69a-e8a9320777ef"));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("0388a973-bfcd-4f2d-a6f4-14df5eb44a16"), "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1402), 32, "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1402), "Sick" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("c992b874-82a7-482a-9ec8-1e1a4720c121"), "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1389), 10, "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1398), "Annual" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("0388a973-bfcd-4f2d-a6f4-14df5eb44a16"));

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("c992b874-82a7-482a-9ec8-1e1a4720c121"));

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("44879e15-c0d4-4db2-b065-5a564483ffee"), "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5070), 32, "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5071), "Sick" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("56f376eb-2470-4b11-b69a-e8a9320777ef"), "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5049), 10, "", new DateTime(2022, 8, 16, 12, 34, 59, 839, DateTimeKind.Utc).AddTicks(5056), "Annual" });
        }
    }
}
