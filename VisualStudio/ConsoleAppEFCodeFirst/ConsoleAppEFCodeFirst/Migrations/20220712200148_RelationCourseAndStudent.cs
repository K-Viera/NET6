using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppEFCodeFirst.Migrations
{
    public partial class RelationCourseAndStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_students_StudentId1",
                table: "students",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_courses_StudentId",
                table: "courses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_students_StudentId",
                table: "courses",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_students_StudentId1",
                table: "students",
                column: "StudentId1",
                principalTable: "students",
                principalColumn: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_students_StudentId",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_students_students_StudentId1",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_StudentId1",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_courses_StudentId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "courses");
        }
    }
}
