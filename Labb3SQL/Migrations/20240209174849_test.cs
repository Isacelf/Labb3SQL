using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3SQL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Befattningar",
                columns: table => new
                {
                    befattningsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    befattningstyp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Befattni__75F2456BF1E2A8D5", x => x.befattningsID);
                });

            migrationBuilder.CreateTable(
                name: "Betygssystem",
                columns: table => new
                {
                    BetygID = table.Column<int>(type: "int", nullable: false),
                    BetygText = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Betygssy__E90ED048BA825088", x => x.BetygID);
                });

            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    KursID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kursnamn = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kurs__BCCFFF3B75D9DD9D", x => x.KursID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ElevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    klassnamn = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    personnummer = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    förnamn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    efternamn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__4AE80D032FCE6C54", x => x.ElevID);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    PersonalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    befattningsID = table.Column<int>(type: "int", nullable: true),
                    personnummer = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.PersonalID);
                    table.ForeignKey(
                        name: "FK__Personal__befatt__4222D4EF",
                        column: x => x.befattningsID,
                        principalTable: "Befattningar",
                        principalColumn: "befattningsID");
                });

            migrationBuilder.CreateTable(
                name: "Betyg",
                columns: table => new
                {
                    betygID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(type: "date", nullable: false),
                    ElevID = table.Column<int>(type: "int", nullable: true),
                    KursID = table.Column<int>(type: "int", nullable: true),
                    PersonalID = table.Column<int>(type: "int", nullable: true),
                    Betyg = table.Column<int>(type: "int", nullable: true),
                    BetygText = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betyg", x => x.betygID);
                    table.ForeignKey(
                        name: "FK__Betyg__ElevID__44FF419A",
                        column: x => x.ElevID,
                        principalTable: "Student",
                        principalColumn: "ElevID");
                    table.ForeignKey(
                        name: "FK__Betyg__KursID__45F365D3",
                        column: x => x.KursID,
                        principalTable: "Kurs",
                        principalColumn: "KursID");
                    table.ForeignKey(
                        name: "FK__Betyg__PersonalI__46E78A0C",
                        column: x => x.PersonalID,
                        principalTable: "Personal",
                        principalColumn: "PersonalID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Betyg_ElevID",
                table: "Betyg",
                column: "ElevID");

            migrationBuilder.CreateIndex(
                name: "IX_Betyg_KursID",
                table: "Betyg",
                column: "KursID");

            migrationBuilder.CreateIndex(
                name: "IX_Betyg_PersonalID",
                table: "Betyg",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_befattningsID",
                table: "Personal",
                column: "befattningsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Betyg");

            migrationBuilder.DropTable(
                name: "Betygssystem");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Befattningar");
        }
    }
}
