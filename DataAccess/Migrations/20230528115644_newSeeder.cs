using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class newSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Name" },
                values: new object[] { new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo DiCaprio" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Name" },
                values: new object[] { new DateTime(1962, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve Carell" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
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
                table: "ContentGenres",
                columns: new[] { "ContentId", "GenreId" },
                values: new object[] { 29, 4 });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "ContentCategoryId", "Name", "NumberOfSubscribers", "ReleaseDate" },
                values: new object[,]
                {
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
                    { 19, 1, "The Godfather", 0, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "ContentCategoryId", "Name", "NumberOfSubscribers", "ReleaseDate" },
                values: new object[,]
                {
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
                    { 43, 1, "Star Wars: Episode VII - The Force Awakens", 0, new DateTime(2015, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
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
                    { 3, 2 },
                    { 5, 2 },
                    { 9, 2 },
                    { 13, 2 },
                    { 16, 2 },
                    { 20, 2 },
                    { 24, 2 },
                    { 27, 2 },
                    { 31, 2 },
                    { 35, 2 },
                    { 4, 3 },
                    { 6, 3 },
                    { 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "ContentGenres",
                columns: new[] { "ContentId", "GenreId" },
                values: new object[,]
                {
                    { 14, 3 },
                    { 18, 3 },
                    { 22, 3 },
                    { 25, 3 },
                    { 30, 3 },
                    { 33, 3 },
                    { 38, 3 },
                    { 4, 4 },
                    { 8, 4 },
                    { 12, 4 },
                    { 17, 4 },
                    { 21, 4 },
                    { 26, 4 },
                    { 34, 4 },
                    { 37, 4 },
                    { 39, 5 },
                    { 40, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 13, 33 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 14, 14 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 16, 16 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 17, 17 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 18, 18 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 19, 19 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 21, 21 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 22, 22 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 23, 22 });

            migrationBuilder.DeleteData(
                table: "ContentActors",
                keyColumns: new[] { "ActorId", "ContentId" },
                keyValues: new object[] { 24, 40 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 28, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 36, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 39, 1 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 24, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 27, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 31, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 35, 2 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 30, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 33, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 38, 3 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 17, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 21, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 26, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 29, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 34, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 37, 4 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 39, 5 });

            migrationBuilder.DeleteData(
                table: "ContentGenres",
                keyColumns: new[] { "ContentId", "GenreId" },
                keyValues: new object[] { 40, 5 });

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Name" },
                values: new object[] { new DateTime(1983, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonah Hill" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Name" },
                values: new object[] { new DateTime(1992, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Freddie Highmore" });

            migrationBuilder.InsertData(
                table: "ContentActors",
                columns: new[] { "ActorId", "ContentId" },
                values: new object[] { 3, 2 });
        }
    }
}
