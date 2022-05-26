using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeveloperStudio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperStudio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperStudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGame_DeveloperStudio_DeveloperStudioId",
                        column: x => x.DeveloperStudioId,
                        principalTable: "DeveloperStudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGame_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeveloperStudio",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("32d88b31-afa7-42ef-9e63-352c398408ba"), "ActivisionBlizzard" },
                    { new Guid("940467c3-32d2-4149-bd8b-d1876bae1318"), "Valve" },
                    { new Guid("cfac1b0d-5780-4f6e-bf8e-53d1ed19536d"), "Panic Button Games" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("67c016fa-99cc-43af-b626-3809f38971b6"), "MMO RPG" },
                    { new Guid("8ddabede-af78-414e-a786-9368f74a7abb"), "Horror" },
                    { new Guid("9b75d1cb-b714-41ed-b0df-be8ffdb10e26"), "Shooter" }
                });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "DeveloperStudioId", "GenreId", "Name" },
                values: new object[,]
                {
                    { new Guid("b6adad18-ffd2-4cf2-add4-b03c462c5b62"), new Guid("940467c3-32d2-4149-bd8b-d1876bae1318"), new Guid("8ddabede-af78-414e-a786-9368f74a7abb"), "Left 4 Dead" },
                    { new Guid("cb1f1b39-12ea-4458-9d36-51dac268fe21"), new Guid("32d88b31-afa7-42ef-9e63-352c398408ba"), new Guid("67c016fa-99cc-43af-b626-3809f38971b6"), "World of warcraft" },
                    { new Guid("d03ef913-6d54-41cc-8f59-4a5a90b4d292"), new Guid("cfac1b0d-5780-4f6e-bf8e-53d1ed19536d"), new Guid("9b75d1cb-b714-41ed-b0df-be8ffdb10e26"), "Apex Legends" },
                    { new Guid("eee8f6ea-2096-47fb-a4a1-9de9cd41771d"), new Guid("940467c3-32d2-4149-bd8b-d1876bae1318"), new Guid("8ddabede-af78-414e-a786-9368f74a7abb"), "Half-Life 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_DeveloperStudioId",
                table: "VideoGame",
                column: "DeveloperStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_GenreId",
                table: "VideoGame",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGame");

            migrationBuilder.DropTable(
                name: "DeveloperStudio");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
