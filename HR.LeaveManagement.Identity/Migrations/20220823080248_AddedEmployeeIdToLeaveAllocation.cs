using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Identity.Migrations
{
    public partial class AddedEmployeeIdToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "281da1c5-74b7-47a3-b8cd-2e19f0b9c4f0",
                column: "ConcurrencyStamp",
                value: "96e60ad1-8f96-4be6-ab5c-9d8a36fea3e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bd5bce7-6bf9-4d3f-82d5-3b31c0267a16",
                column: "ConcurrencyStamp",
                value: "b59b4edb-cea6-45ee-8dd2-31db73e3c714");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52902de6-aeb7-4df5-86e3-26e203b6ccc5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00857323-4e99-4177-8c6c-5b73f4420365", "AQAAAAEAACcQAAAAEN7jxuEkgIbhRZS9dx7ony3YNsY1147BH7x6XzWbWRevjmTxktdrxmPi+eP0brMYWw==", "0848ec17-a177-4fcc-a22e-856e8404159e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff4b2a5c-f027-4ae4-a1e8-76ed3ca395c2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6265eaa6-dfc0-4614-95e1-ebbc87f39ee8", "AQAAAAEAACcQAAAAEBsDbHz3w81kAU5PdvrxwHYTfbyKjX6GyrdnGy9d2AEbbR7IgMp8jgG32XsV1tEFWg==", "89999b5b-32e3-4f6f-9fb9-9c8dccecabd6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "281da1c5-74b7-47a3-b8cd-2e19f0b9c4f0",
                column: "ConcurrencyStamp",
                value: "9ce692dd-1f84-4214-b850-855edd3c0d55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bd5bce7-6bf9-4d3f-82d5-3b31c0267a16",
                column: "ConcurrencyStamp",
                value: "ad78b270-d50f-4349-ab43-1d547f8d0375");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52902de6-aeb7-4df5-86e3-26e203b6ccc5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c99b447b-c237-4dc5-8a1a-bea0a70b0104", "AQAAAAEAACcQAAAAEIVsDA/F62MmqCJ3wnxN37r12/90TBRfXczsYCv/f+YVBrpc87yiCPmH0ujOKjRnQg==", "22a5b220-f9ee-40ad-a9ff-d8485a7c61c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff4b2a5c-f027-4ae4-a1e8-76ed3ca395c2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acb2a9c5-321e-4555-b9f2-713048db1d19", "AQAAAAEAACcQAAAAEEZ0wJ+WQ4slpcGDGTetnpeXRita3CP0A7T6BwmGYsG70GGIVAkgukeRQEJ5Hjpz9w==", "57f90981-9051-4d8b-a25c-42aa5bc98d65" });
        }
    }
}
