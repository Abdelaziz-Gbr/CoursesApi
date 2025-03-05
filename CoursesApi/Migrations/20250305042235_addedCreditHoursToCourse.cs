using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesApi.Migrations
{
    /// <inheritdoc />
    public partial class addedCreditHoursToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditHours",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "Courses");
        }
    }
}
