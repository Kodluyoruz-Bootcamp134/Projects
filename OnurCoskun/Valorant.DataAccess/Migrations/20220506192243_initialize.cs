using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valorant.DataAccess.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "CodeName", "Gender", "ImageUrl", "Origin", "Race", "RealName", "Role" },
                values: new object[] { 1, "Jett", "Female", "http://placehold.it/300x300", "South Korea", "Radiant", "Sunwoo Han", "Duelist" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "CodeName", "Gender", "ImageUrl", "Origin", "Race", "RealName", "Role" },
                values: new object[] { 2, "Phoenix", "Male", "http://placehold.it/300x300", "United Kingdom", "Radiant", "Jamie Adeyemi", "Duelist" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "CodeName", "Gender", "ImageUrl", "Origin", "Race", "RealName", "Role" },
                values: new object[] { 3, "Fade", "Female", "http://placehold.it/300x300", "Turkey", "Radiant", "Unknown", "İnitiator" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "AgentId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Send forward a prowler that chases the first enemy or trail it sees, nearsighting its target on impact.", "Prowler" },
                    { 2, 3, "Throw a knot of fear that ruptures on impact with the ground, holding enemies in place and afflicting them with deafness and decay.", "Seize" },
                    { 3, 3, "Throw a watcher that lashes out on impact with the ground, revealing enemies in its line of sight and creating trails to them.", "Haunt" },
                    { 4, 3, "Unleash a wave of nightmare energy, afflicting caught enemies with trails, deafeness, and decay.", "Nightfall" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AgentId",
                table: "Skills",
                column: "AgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
