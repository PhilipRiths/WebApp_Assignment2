using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GymBuddyWebApp.Data.Migrations
{
    public partial class NewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardioContests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardioContestId = table.Column<int>(nullable: true),
                    ExerciseTypes = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardioContests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardioContests_CardioContests_CardioContestId",
                        column: x => x.CardioContestId,
                        principalTable: "CardioContests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cardio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardioType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cardio_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardioContestId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_CardioContests_CardioContestId",
                        column: x => x.CardioContestId,
                        principalTable: "CardioContests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competitions_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ExerciseType = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weights_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardio_PersonId",
                table: "Cardio",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CardioContests_CardioContestId",
                table: "CardioContests",
                column: "CardioContestId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CardioContestId",
                table: "Competitions",
                column: "CardioContestId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_PersonId",
                table: "Competitions",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Weights_PersonId",
                table: "Weights",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cardio");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "CardioContests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
