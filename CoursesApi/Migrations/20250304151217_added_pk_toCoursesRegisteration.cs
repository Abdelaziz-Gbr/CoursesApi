using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesApi.Migrations
{
    /// <inheritdoc />
    public partial class added_pk_toCoursesRegisteration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the new column (RegisterationId)
            migrationBuilder.AddColumn<Guid>(
                name: "RegisterationId",
                table: "StudentCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()"); // Generates a unique GUID

            // Set RegisterationId as the primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                column: "RegisterationId");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterationId",
                table: "StudentCourses");
        }
    }
}
