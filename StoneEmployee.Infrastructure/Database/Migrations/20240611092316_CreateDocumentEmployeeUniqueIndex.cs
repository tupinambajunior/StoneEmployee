using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneEmployee.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateDocumentEmployeeUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "admission_data",
                table: "employee",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_employee_document",
                table: "employee",
                column: "document",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_employee_document",
                table: "employee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "admission_data",
                table: "employee",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
