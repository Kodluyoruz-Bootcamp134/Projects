using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Characters.Dal.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    isAlive = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Elves" },
                    { 2, "Men" },
                    { 3, "Dwarves" },
                    { 5, "Hobbits" },
                    { 6, "Orcs" },
                    { 7, "Ents" },
                    { 8, "Maiar" },
                    { 9, "Trolls" },
                    { 10, "Barrow-wights" },
                    { 11, "Balrogs" },
                    { 12, "Dragons" },
                    { 13, "Easterlings" },
                    { 14, "Valar" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "ImageUrl", "Name", "RaceId", "isAlive" },
                values: new object[,]
                {
                    { 1, 75, "https://static.wikia.nocookie.net/ortadunya/images/3/34/Aragorn2.jpg/revision/latest?cb=20210609105006", "Aragorn", 2, true },
                    { 2, 150, "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest?cb=20121110131754", "Gandalf", 8, true },
                    { 3, 43, "https://static.wikia.nocookie.net/lotr/images/b/b4/Seanbean_boromir.jpg/revision/latest?cb=20110327195115", "Boromir", 2, false },
                    { 4, 66, "https://static.wikia.nocookie.net/middle-earth-film-saga/images/7/77/Legolas.png/revision/latest/top-crop/width/360/height/450?cb=20160207050831", "Legolas", 1, true },
                    { 5, 135, "https://static.wikia.nocookie.net/lotr/images/5/59/Witch-king.jpg/revision/latest?cb=20220209185252", "Witch King", 2, false },
                    { 6, 63, "https://static.wikia.nocookie.net/ortadunya/images/4/43/Gimli.jpg/revision/latest/top-crop/width/360/height/450?cb=20190424060619", "Gimli", 3, true },
                    { 7, 200, "https://static.wikia.nocookie.net/ortadunya/images/0/06/Gilgalad.jpg/revision/latest/top-crop/width/360/height/450?cb=20190628103851", "Gil-Galad", 1, true },
                    { 8, 150, "https://static.wikia.nocookie.net/lotr/images/0/0c/Christopher_Lee_as_Saruman.jpg/revision/latest/top-crop/width/360/height/360?cb=20170127113833", "Saruman", 8, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaceId",
                table: "Characters",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
