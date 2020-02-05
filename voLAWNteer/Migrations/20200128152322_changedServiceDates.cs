using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace voLAWNteer.Migrations
{
    public partial class changedServiceDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c6d241a-630d-43ae-b844-fcdfb6e8ae67", "AQAAAAEAACcQAAAAENqwTKJ/bQo2XsYxXfZVQYF/j5JwS6BdQfTb8RuIxNVfP1Y34oC+RXZL1BmnS1bTJQ==" });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedDate", "ListingCreated" },
                values: new object[] { new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2,
                column: "ListingCreated",
                value: new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3,
                column: "ListingCreated",
                value: new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
