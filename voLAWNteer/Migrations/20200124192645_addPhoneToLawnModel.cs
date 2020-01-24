using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace voLAWNteer.Migrations
{
    public partial class addPhoneToLawnModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Lawn",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73f43abf-96a1-4b8f-a4be-f6133c48be37", "AQAAAAEAACcQAAAAEDAAlDR3uA26tO5PuOKWEV2CCBwGaaydtAPnD1pQKeKr3ZLN8vqTmmwr20AJTGc5vQ==" });

            migrationBuilder.UpdateData(
                table: "Lawn",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "1-304-949-6521");

            migrationBuilder.UpdateData(
                table: "Lawn",
                keyColumn: "Id",
                keyValue: 2,
                column: "Phone",
                value: "1-304-555-7846");

            migrationBuilder.UpdateData(
                table: "Lawn",
                keyColumn: "Id",
                keyValue: 3,
                column: "Phone",
                value: "1-304-342-5487");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletedDate",
                value: new DateTime(2020, 1, 24, 14, 26, 44, 945, DateTimeKind.Local).AddTicks(6913));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Lawn");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4308fd36-40d2-455c-a4c2-ffc3a644902e", "AQAAAAEAACcQAAAAEMapZmZaiIEmtqNvIDj/MVEwvBHaQYH+G3kl+z498uLhqsUKtWPDYfplG0cqt95M6g==" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletedDate",
                value: new DateTime(2020, 1, 24, 10, 17, 27, 951, DateTimeKind.Local).AddTicks(1542));
        }
    }
}
