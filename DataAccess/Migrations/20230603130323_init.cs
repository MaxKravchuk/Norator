using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfSubscribers = table.Column<int>(type: "int", nullable: false),
                    ContentCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_ContentCategories_ContentCategoryId",
                        column: x => x.ContentCategoryId,
                        principalTable: "ContentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentActors",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentActors", x => new { x.ActorId, x.ContentId });
                    table.ForeignKey(
                        name: "FK_ContentActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentActors_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentGenres",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentGenres", x => new { x.GenreId, x.ContentId });
                    table.ForeignKey(
                        name: "FK_ContentGenres_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContents",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContents", x => new { x.UserId, x.ContentId });
                    table.ForeignKey(
                        name: "FK_UserContents_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo DiCaprio" },
                    { 2, new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnny Depp" },
                    { 3, new DateTime(1962, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve Carell" },
                    { 4, new DateTime(2004, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Millie Bobby Brown" },
                    { 5, new DateTime(1980, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Justin Roiland" },
                    { 6, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { 7, new DateTime(1944, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Craig T. Nelson" },
                    { 8, new DateTime(1929, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edward Asner" },
                    { 9, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer Hale" },
                    { 10, new DateTime(1980, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie Hunnam" },
                    { 11, new DateTime(1983, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Henry Cavill" },
                    { 12, new DateTime(1916, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gregory Peck" },
                    { 13, new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Hardy" },
                    { 14, new DateTime(1989, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Radcliffe" },
                    { 15, new DateTime(1954, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Travolta" },
                    { 16, new DateTime(1958, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tim Robbins" },
                    { 17, new DateTime(1969, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matthew McConaughey" },
                    { 18, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { 19, new DateTime(1924, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marlon Brando" },
                    { 20, new DateTime(1981, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bryce Dallas Howard" },
                    { 21, new DateTime(1956, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bryan Cranston" },
                    { 22, new DateTime(1986, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kit Harington" },
                    { 23, new DateTime(1986, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emilia Clarke" },
                    { 24, new DateTime(1952, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam Neeson" },
                    { 25, new DateTime(1985, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gal Gadot" }
                });

            migrationBuilder.InsertData(
                table: "ContentCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Film" },
                    { 2, "Series" },
                    { 3, "Cartoon" },
                    { 4, "Game" },
                    { 5, "Book" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Comedy" },
                    { 2, "Drama" },
                    { 3, "Sci-fi" },
                    { 4, "Adventure" },
                    { 5, "Family" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "NickName", "Password", "UserType" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "123Admin#", 0 },
                    { 2, new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarakan", "123Tarakan#", 1 }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "ContentCategoryId", "Name", "NumberOfSubscribers", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, "Don`t Look Up", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Charlie and the Chocolate Factory", 0, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "The Office", 0, new DateTime(2005, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Stranger Things", 0, new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "Rick and Morty", 0, new DateTime(2013, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Moana", 0, new DateTime(2016, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, "The Incredibles", 0, new DateTime(2004, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, "Up", 0, new DateTime(2009, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, "Mass Effect Legendary Edition", 0, new DateTime(2021, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 4, "The Legend of Zelda: Breath of the Wild", 0, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 4, "The Witcher 3: Wild Hunt", 0, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 5, "To Kill a Mockingbird", 0, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 5, "1984", 0, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 5, "Harry Potter and the Philosopher's Stone", 0, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, "Pulp Fiction", 0, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, "The Shawshank Redemption", 0, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, "Interstellar", 0, new DateTime(2014, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, "Avengers: Endgame", 0, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, "The Godfather", 0, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 2, "Black Mirror", 0, new DateTime(2011, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 2, "Breaking Bad", 0, new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, "Game of Thrones", 0, new DateTime(2011, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, "Finding Nemo", 0, new DateTime(2003, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 3, "Toy Story", 0, new DateTime(1995, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 3, "Frozen", 0, new DateTime(2013, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 4, "Red Dead Redemption 2", 0, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 4, "The Elder Scrolls V: Skyrim", 0, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 4, "Minecraft", 0, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 5, "The Great Gatsby", 0, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, "The Hangover", 0, new DateTime(2009, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 1, "La La Land", 0, new DateTime(2016, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 1, "Inception", 0, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 1, "The Notebook", 0, new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 2, "The Big Bang Theory", 0, new DateTime(2007, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 2, "Friends", 0, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 1, "Star Wars: Episode IV - A New Hope", 0, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 1, "Star Wars: Episode V - The Empire Strikes Back", 0, new DateTime(1980, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 1, "Star Wars: Episode VI - Return of the Jedi", 0, new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 1, "Star Wars: Episode I - The Phantom Menace", 0, new DateTime(1999, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 1, "Star Wars: Episode II - Attack of the Clones", 0, new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 1, "Star Wars: Episode III - Revenge of the Sith", 0, new DateTime(2005, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 1, "Star Wars: Episode VII - The Force Awakens", 0, new DateTime(2015, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "ContentCategoryId", "Name", "NumberOfSubscribers", "ReleaseDate" },
                values: new object[,]
                {
                    { 44, 1, "Star Wars: Episode VIII - The Last Jedi", 0, new DateTime(2017, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 1, "Star Wars: Episode IX - The Rise of Skywalker", 0, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 2, "Star Wars: The Clone Wars", 0, new DateTime(2008, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 2, "Star Wars Rebels", 0, new DateTime(2014, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 2, "The Mandalorian", 0, new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 2, "Star Wars: The Bad Batch", 0, new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 4, "Among Us", 0, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ContentActors",
                columns: new[] { "ActorId", "ContentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 12, 12 },
                    { 13, 33 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 22 },
                    { 24, 40 }
                });

            migrationBuilder.InsertData(
                table: "ContentGenres",
                columns: new[] { "ContentId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 5, 1 },
                    { 7, 1 },
                    { 11, 1 },
                    { 15, 1 },
                    { 19, 1 },
                    { 23, 1 },
                    { 28, 1 },
                    { 32, 1 },
                    { 36, 1 },
                    { 39, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 5, 2 },
                    { 9, 2 },
                    { 13, 2 },
                    { 16, 2 },
                    { 20, 2 },
                    { 24, 2 },
                    { 27, 2 }
                });

            migrationBuilder.InsertData(
                table: "ContentGenres",
                columns: new[] { "ContentId", "GenreId" },
                values: new object[,]
                {
                    { 31, 2 },
                    { 35, 2 },
                    { 1, 3 },
                    { 4, 3 },
                    { 6, 3 },
                    { 10, 3 },
                    { 14, 3 },
                    { 18, 3 },
                    { 22, 3 },
                    { 25, 3 },
                    { 30, 3 },
                    { 33, 3 },
                    { 38, 3 },
                    { 2, 4 },
                    { 4, 4 },
                    { 8, 4 },
                    { 12, 4 },
                    { 17, 4 },
                    { 21, 4 },
                    { 26, 4 },
                    { 34, 4 },
                    { 37, 4 },
                    { 2, 5 },
                    { 39, 5 },
                    { 40, 5 }
                });

            migrationBuilder.InsertData(
                table: "UserContents",
                columns: new[] { "ContentId", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ContentActors_ContentId",
                table: "ContentActors",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentGenres_ContentId",
                table: "ContentGenres",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ContentCategoryId",
                table: "Contents",
                column: "ContentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserContents_ContentId",
                table: "UserContents",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NickName",
                table: "Users",
                column: "NickName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentActors");

            migrationBuilder.DropTable(
                name: "ContentGenres");

            migrationBuilder.DropTable(
                name: "UserContents");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ContentCategories");
        }
    }
}
