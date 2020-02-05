using Microsoft.EntityFrameworkCore.Migrations;

namespace voLAWNteer.Migrations
{
    public partial class EFToldMeTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a74a0068-e76f-4144-91a7-2ba3a1a49bdb", "AQAAAAEAACcQAAAAENT5dQbJkt3ny5SezsRI93yJiTk4RiVMJBa8jnWa3fwpGXP42AYv/H1VDrwP7oRMsQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c6d241a-630d-43ae-b844-fcdfb6e8ae67", "AQAAAAEAACcQAAAAENqwTKJ/bQo2XsYxXfZVQYF/j5JwS6BdQfTb8RuIxNVfP1Y34oC+RXZL1BmnS1bTJQ==" });
        }
    }
}
