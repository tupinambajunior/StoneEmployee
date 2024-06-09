using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneEmployee.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    document = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    sector = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    gross_salary = table.Column<decimal>(type: "numeric", nullable: false),
                    admission_data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    has_health_plan = table.Column<bool>(type: "boolean", nullable: false),
                    has_dental_plan = table.Column<bool>(type: "boolean", nullable: false),
                    has_transportation_vouchers = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
