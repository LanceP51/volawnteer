using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace voLAWNteer.Migrations
{
    public partial class addedAppUserToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "ZipCode",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e2f029d-ebc1-484b-8e6d-8b6b3aa4d815", "AQAAAAEAACcQAAAAEMHMZ2XQ7YUccbeCjQ5E695po2LsLSWcVH5j11pzHSityWivnaEV9BDNAM0B8FXqdw==" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedDate", "ListingCreated" },
                values: new object[] { new DateTime(2020, 1, 27, 9, 46, 36, 586, DateTimeKind.Local).AddTicks(4015), new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "ListingCreated",
                value: new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "ListingCreated",
                value: new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ZipCode",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "PasswordHash" },
                values: new object[] { "215599c9-573f-4764-90d5-e48b5e2ac295", "ApplicationUser", "AQAAAAEAACcQAAAAEGFx3wM/FVOj075TFtjXYNmAeSKUOQvCT4G58vLjfyib/l2GZtP2USQeKa22oIP1PA==" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedDate", "ListingCreated" },
                values: new object[] { new DateTime(2020, 1, 24, 16, 13, 2, 306, DateTimeKind.Local).AddTicks(9779), new DateTime(2020, 1, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "ListingCreated",
                value: new DateTime(2020, 1, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "ListingCreated",
                value: new DateTime(2020, 1, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
