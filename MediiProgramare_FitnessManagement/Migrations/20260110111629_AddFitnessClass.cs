using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiProgramare_FitnessManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddFitnessClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Class_ClassID",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "Booking",
                newName: "FitnessClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ClassID",
                table: "Booking",
                newName: "IX_Booking_FitnessClassID");

            migrationBuilder.CreateTable(
                name: "FitnessClasses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: false),
                    ClassTypeID = table.Column<int>(type: "int", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessClasses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FitnessClasses_ClassType_ClassTypeID",
                        column: x => x.ClassTypeID,
                        principalTable: "ClassType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessClasses_Gym_GymID",
                        column: x => x.GymID,
                        principalTable: "Gym",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FitnessClasses_Trainer_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClasses_ClassTypeID",
                table: "FitnessClasses",
                column: "ClassTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClasses_GymID",
                table: "FitnessClasses",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClasses_TrainerID",
                table: "FitnessClasses",
                column: "TrainerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_FitnessClasses_FitnessClassID",
                table: "Booking",
                column: "FitnessClassID",
                principalTable: "FitnessClasses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_FitnessClasses_FitnessClassID",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "FitnessClasses");

            migrationBuilder.RenameColumn(
                name: "FitnessClassID",
                table: "Booking",
                newName: "ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_FitnessClassID",
                table: "Booking",
                newName: "IX_Booking_ClassID");

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassTypeID = table.Column<int>(type: "int", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: true),
                    TrainerID = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Class_ClassType_ClassTypeID",
                        column: x => x.ClassTypeID,
                        principalTable: "ClassType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Gym_GymID",
                        column: x => x.GymID,
                        principalTable: "Gym",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Class_Trainer_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_ClassTypeID",
                table: "Class",
                column: "ClassTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_GymID",
                table: "Class",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TrainerID",
                table: "Class",
                column: "TrainerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Class_ClassID",
                table: "Booking",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
