using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace voLAWNteer.Migrations
{
    public partial class nullableApprovedBoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "Lawn",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "215599c9-573f-4764-90d5-e48b5e2ac295", "AQAAAAEAACcQAAAAEGFx3wM/FVOj075TFtjXYNmAeSKUOQvCT4G58vLjfyib/l2GZtP2USQeKa22oIP1PA==" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletedDate",
                value: new DateTime(2020, 1, 24, 16, 13, 2, 306, DateTimeKind.Local).AddTicks(9779));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "Lawn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73f43abf-96a1-4b8f-a4be-f6133c48be37", "AQAAAAEAACcQAAAAEDAAlDR3uA26tO5PuOKWEV2CCBwGaaydtAPnD1pQKeKr3ZLN8vqTmmwr20AJTGc5vQ==" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletedDate",
                value: new DateTime(2020, 1, 24, 14, 26, 44, 945, DateTimeKind.Local).AddTicks(6913));
        }
    }
}
