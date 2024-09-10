using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qinshift.Movies.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "Plot", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 10, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 2, 1, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { 3, 4, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 4, 10, "In the Second Age of Middle-earth, the lords of Elves, Dwarves, and Men are given Rings of Power. Unbeknownst to them, the Dark Lord Sauron forges the One Ring in Mount Doom, instilling into it a great part of his power", new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring" },
                    { 5, 1, "Awakening from a dream of Gandalf fighting the Balrog in Moria[a], Frodo Baggins finds himself, along with Samwise Gamgee, lost in the Emyn Muil near Mordor. They discover that they are being tracked by Gollum", new DateTime(2002, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Two Towers" },
                    { 6, 4, "Harry is a wizard.", new DateTime(2012, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Admin", "Administrator", "!#/)zW??C?JJ??", "admin" },
                    { 2, "Boris", "Krstovski", "?!o?g?W?&?jT??", "boris" },
                    { 3, "Test", "Testing", "??G??????vh????", "test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
