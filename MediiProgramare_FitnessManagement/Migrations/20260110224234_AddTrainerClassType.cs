using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiProgramare_FitnessManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainerClassType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainerClassType",
                columns: table => new
                {
                    TrainerID = table.Column<int>(type: "int", nullable: false),
                    ClassTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerClassType", x => new { x.TrainerID, x.ClassTypeID });
                    table.ForeignKey(
                        name: "FK_TrainerClassType_ClassType_ClassTypeID",
                        column: x => x.ClassTypeID,
                        principalTable: "ClassType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerClassType_Trainer_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClassType_ClassTypeID",
                table: "TrainerClassType",
                column: "ClassTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerClassType");
        }
    }
}
