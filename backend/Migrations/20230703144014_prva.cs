using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "radnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPosla = table.Column<int>(type: "int", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radnik", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "posao",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "a" },
                    { 2, "b" },
                    { 3, "c" }
                });

            migrationBuilder.InsertData(
                table: "radnik",
                columns: new[] { "Id", "IdPosla", "Ime", "Lozinka", "Prezime" },
                values: new object[,]
                {
                    { 1, 1, "Radnik1", "1", "pre1" },
                    { 2, 2, "Radnik2", "1", "pre2" },
                    { 3, 3, "Radnik3", "1", "pre3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posao");

            migrationBuilder.DropTable(
                name: "radnik");
        }
    }
}
