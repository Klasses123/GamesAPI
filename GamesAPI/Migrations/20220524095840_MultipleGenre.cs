using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    public partial class MultipleGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGame_Genre_GenreId",
                table: "VideoGame");

            migrationBuilder.DropIndex(
                name: "IX_VideoGame_GenreId",
                table: "VideoGame");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "VideoGame");

            migrationBuilder.CreateTable(
                name: "VideoGameGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGameGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGameGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGameGenre_VideoGame_GameId",
                        column: x => x.GameId,
                        principalTable: "VideoGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VideoGameGenre",
                columns: new[] { "Id", "GameId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("2b5c4fb6-d563-4f31-aeac-60e8c16102ee"), new Guid("d03ef913-6d54-41cc-8f59-4a5a90b4d292"), new Guid("9b75d1cb-b714-41ed-b0df-be8ffdb10e26") },
                    { new Guid("3bfbd03d-bf3a-4137-863e-b89ff446d87c"), new Guid("eee8f6ea-2096-47fb-a4a1-9de9cd41771d"), new Guid("8ddabede-af78-414e-a786-9368f74a7abb") },
                    { new Guid("4d95eb9b-4fb4-4a35-96af-d71961fff409"), new Guid("b6adad18-ffd2-4cf2-add4-b03c462c5b62"), new Guid("8ddabede-af78-414e-a786-9368f74a7abb") },
                    { new Guid("782412f4-53cb-402e-a830-21a5b43be849"), new Guid("b6adad18-ffd2-4cf2-add4-b03c462c5b62"), new Guid("9b75d1cb-b714-41ed-b0df-be8ffdb10e26") },
                    { new Guid("7b878b48-17fc-4142-b466-153005e439bf"), new Guid("eee8f6ea-2096-47fb-a4a1-9de9cd41771d"), new Guid("9b75d1cb-b714-41ed-b0df-be8ffdb10e26") },
                    { new Guid("e4387219-6daa-4e9b-ae04-5037cd911332"), new Guid("cb1f1b39-12ea-4458-9d36-51dac268fe21"), new Guid("67c016fa-99cc-43af-b626-3809f38971b6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGameGenre_GameId",
                table: "VideoGameGenre",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGameGenre_GenreId",
                table: "VideoGameGenre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGameGenre");

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "VideoGame",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: new Guid("b6adad18-ffd2-4cf2-add4-b03c462c5b62"),
                column: "GenreId",
                value: new Guid("8ddabede-af78-414e-a786-9368f74a7abb"));

            migrationBuilder.UpdateData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: new Guid("cb1f1b39-12ea-4458-9d36-51dac268fe21"),
                column: "GenreId",
                value: new Guid("67c016fa-99cc-43af-b626-3809f38971b6"));

            migrationBuilder.UpdateData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: new Guid("d03ef913-6d54-41cc-8f59-4a5a90b4d292"),
                column: "GenreId",
                value: new Guid("9b75d1cb-b714-41ed-b0df-be8ffdb10e26"));

            migrationBuilder.UpdateData(
                table: "VideoGame",
                keyColumn: "Id",
                keyValue: new Guid("eee8f6ea-2096-47fb-a4a1-9de9cd41771d"),
                column: "GenreId",
                value: new Guid("8ddabede-af78-414e-a786-9368f74a7abb"));

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_GenreId",
                table: "VideoGame",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGame_Genre_GenreId",
                table: "VideoGame",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
