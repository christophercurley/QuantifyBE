using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantifyBE.Migrations
{
    /// <inheritdoc />
    public partial class SetUpExerciseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineExerciseDetails",
                columns: table => new
                {
                    RoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExerciseDetails", x => new { x.RoutineId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_RoutineExerciseDetails_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutineExerciseDetails_Routine_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Routine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetDetail_RoutineExerciseDetails_RoutineId_ExerciseId",
                        columns: x => new { x.RoutineId, x.ExerciseId },
                        principalTable: "RoutineExerciseDetails",
                        principalColumns: new[] { "RoutineId", "ExerciseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExerciseDetails_ExerciseId",
                table: "RoutineExerciseDetails",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_SetDetail_RoutineId_ExerciseId",
                table: "SetDetail",
                columns: new[] { "RoutineId", "ExerciseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetDetail");

            migrationBuilder.DropTable(
                name: "RoutineExerciseDetails");

            migrationBuilder.DropTable(
                name: "Routine");
        }
    }
}
