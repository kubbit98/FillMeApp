using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FillMeApp.Server.Migrations
{
    public partial class FillMeAppFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PartyId = table.Column<string>(type: "varchar(8)", nullable: true),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    PartyId = table.Column<string>(type: "varchar(8)", nullable: true),
                    Nick = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Users_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "party1", "Party for development", "Party number one" });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { "party2", "Party for development", "Party number two" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "Description", "Name", "PartyId" },
                values: new object[,]
                {
                    { 1, "For development", "First survey", "party1" },
                    { 2, null, "Second survey", "party1" },
                    { 3, null, "Third survey", "party2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Nick", "PartyId" },
                values: new object[,]
                {
                    { "user1", "Zuczek", "party1" },
                    { "user2", "Kornel", "party1" },
                    { "user3", "Szymek", "party2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PartyId",
                table: "Surveys",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PartyId",
                table: "Users",
                column: "PartyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
