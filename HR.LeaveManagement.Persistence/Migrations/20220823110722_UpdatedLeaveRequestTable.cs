using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    public partial class UpdatedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("0388a973-bfcd-4f2d-a6f4-14df5eb44a16"));

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("c992b874-82a7-482a-9ec8-1e1a4720c121"));

            migrationBuilder.AddColumn<string>(
                name: "RequestingEmployeeId",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("8068fc8b-417d-45d7-a982-941e987647cd"), "", new DateTime(2022, 8, 23, 13, 7, 22, 466, DateTimeKind.Local).AddTicks(3095), 32, "", new DateTime(2022, 8, 23, 13, 7, 22, 466, DateTimeKind.Local).AddTicks(3095), "Sick" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("d87b8bb8-a449-467c-97bd-b82e00959651"), "", new DateTime(2022, 8, 23, 13, 7, 22, 466, DateTimeKind.Local).AddTicks(3082), 10, "", new DateTime(2022, 8, 23, 13, 7, 22, 466, DateTimeKind.Local).AddTicks(3090), "Annual" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("8068fc8b-417d-45d7-a982-941e987647cd"));

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: new Guid("d87b8bb8-a449-467c-97bd-b82e00959651"));

            migrationBuilder.DropColumn(
                name: "RequestingEmployeeId",
                table: "LeaveRequests");

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("0388a973-bfcd-4f2d-a6f4-14df5eb44a16"), "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1402), 32, "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1402), "Sick" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("c992b874-82a7-482a-9ec8-1e1a4720c121"), "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1389), 10, "", new DateTime(2022, 8, 23, 10, 7, 22, 98, DateTimeKind.Local).AddTicks(1398), "Annual" });
        }
    }
}
