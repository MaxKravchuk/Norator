using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Init : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exceptions", x => x.Id);
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
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { 1, new DateTime(1983, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonah Hill" },
                    { 2, new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnny Depp" }
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
                values: new object[] { 1, 1, "Don`t Look Up", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021) });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "ContentCategoryId", "Name", "NumberOfSubscribers", "ReleaseDate" },
                values: new object[] { 2, 1, "Charlie and the Chocolate Factory", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2005) });

            migrationBuilder.InsertData(
                table: "ContentActors",
                columns: new[] { "ActorId", "ContentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ContentGenres",
                columns: new[] { "ContentId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 }
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
                name: "IX_UserContents_ContentId",
                table: "UserContents",
                column: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentActors");

            migrationBuilder.DropTable(
                name: "ContentGenres");

            migrationBuilder.DropTable(
                name: "Exceptions");

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
