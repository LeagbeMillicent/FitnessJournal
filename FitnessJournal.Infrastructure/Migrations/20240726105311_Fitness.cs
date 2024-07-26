using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fitness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTrackings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredWorkoutTypes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAchieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityTrackingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_ActivityTrackings_ActivityTrackingId",
                        column: x => x.ActivityTrackingId,
                        principalTable: "ActivityTrackings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutStats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rmks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityTrackingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progresses_ActivityTrackings_ActivityTrackingId",
                        column: x => x.ActivityTrackingId,
                        principalTable: "ActivityTrackings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false),
                    FitnessInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goals_FitnessInformations_FitnessInformationId",
                        column: x => x.FitnessInformationId,
                        principalTable: "FitnessInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Intensity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rmks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityTrackingId = table.Column<int>(type: "int", nullable: true),
                    GoalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_ActivityTrackings_ActivityTrackingId",
                        column: x => x.ActivityTrackingId,
                        principalTable: "ActivityTrackings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workouts_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_ActivityTrackingId",
                table: "Achievements",
                column: "ActivityTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_FitnessInformationId",
                table: "Goals",
                column: "FitnessInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_ActivityTrackingId",
                table: "Progresses",
                column: "ActivityTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ActivityTrackingId",
                table: "Workouts",
                column: "ActivityTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_GoalId",
                table: "Workouts",
                column: "GoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "ActivityTrackings");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "FitnessInformations");
        }
    }
}
