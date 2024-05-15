using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB_LTW_API.Migrations
{
    /// <inheritdoc />
    public partial class THWeb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 1,
                column: "FullName",
                value: "Connan");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 2,
                column: "FullName",
                value: "Tsubasa ");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublishersId",
                keyValue: 1,
                column: "Name",
                value: "NXB Kim Đồng");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublishersId",
                keyValue: 2,
                column: "Name",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 1,
                column: "FullName",
                value: "Connan");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 2,
                column: "FullName",
                value: "Tsubasa");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublishersId",
                keyValue: 1,
                column: "Name",
                value: "NXB Kim Đồng");

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "PublishersId",
                keyValue: 2,
                column: "Name",
                value: "NXB Trẻ");
        }
    }
}
