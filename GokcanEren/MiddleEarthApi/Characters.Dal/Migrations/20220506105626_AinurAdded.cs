using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Characters.Dal.Migrations
{
    public partial class AinurAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Ainur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Valar");
        }
    }
}
