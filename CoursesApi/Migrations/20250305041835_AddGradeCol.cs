using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddGradeCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "grade",
                table: "StudentCourses",
                newName: "Grade");

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "StudentCourses",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

           /* migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                column: "RegisterationId");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");*/

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "StudentCourses",
                newName: "grade");

            migrationBuilder.AlterColumn<float>(
                name: "grade",
                table: "StudentCourses",
                type: "real",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);
        }
    }
}
