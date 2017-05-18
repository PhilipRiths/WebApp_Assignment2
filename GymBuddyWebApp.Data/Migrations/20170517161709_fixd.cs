using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddyWebApp.Data.Migrations
{
    public partial class fixd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseTypes",
                table: "CardioContests");

            migrationBuilder.AddColumn<int>(
                name: "CardioTypes",
                table: "CardioContests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardioTypes",
                table: "CardioContests");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseTypes",
                table: "CardioContests",
                nullable: false,
                defaultValue: 0);
        }
    }
}
