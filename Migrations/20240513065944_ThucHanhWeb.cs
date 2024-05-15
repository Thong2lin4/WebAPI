using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB_LTW_API.Migrations
{
    /// <inheritdoc />
    public partial class ThucHanhWeb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 1,
                column: "FullName",
                value: "Thành Thông");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 2,
                column: "FullName",
                value: "Nguyễn Thành Thông ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 1,
                column: "FullName",
                value: "7 Viên Ngọc Rồng");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorsId",
                keyValue: 2,
                column: "FullName",
                value: "Dế Mèn Phiêu Lưu Ký");
        }
    }
}
