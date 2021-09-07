using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenceTracker.Migrations
{
    public partial class addSourceAndTarget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Target",
                table: "Outcomes");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Incomes");

            migrationBuilder.AddColumn<int>(
                name: "TargetId",
                table: "Outcomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_TargetId",
                table: "Outcomes",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_SourceId",
                table: "Incomes",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Sources_SourceId",
                table: "Incomes",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Outcomes_Targets_TargetId",
                table: "Outcomes",
                column: "TargetId",
                principalTable: "Targets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Sources_SourceId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Outcomes_Targets_TargetId",
                table: "Outcomes");

            migrationBuilder.DropIndex(
                name: "IX_Outcomes_TargetId",
                table: "Outcomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_SourceId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Outcomes");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Incomes");

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "Outcomes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
