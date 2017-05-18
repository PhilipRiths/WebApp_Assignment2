using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddyWebApp.Data.Migrations
{
    public partial class BugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardioContests_CardioContests_CardioContestId",
                table: "CardioContests");

            migrationBuilder.DropIndex(
                name: "IX_CardioContests_CardioContestId",
                table: "CardioContests");

            migrationBuilder.DropColumn(
                name: "CardioContestId",
                table: "CardioContests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardioContestId",
                table: "CardioContests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardioContests_CardioContestId",
                table: "CardioContests",
                column: "CardioContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardioContests_CardioContests_CardioContestId",
                table: "CardioContests",
                column: "CardioContestId",
                principalTable: "CardioContests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
