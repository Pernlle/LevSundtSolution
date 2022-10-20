using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevSundt.SqlServerContextMigrations.Migrations
{
    public partial class TryAgainDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "bmi",
                table: "Bmi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "bmi",
                table: "Bmi");
        }
    }
}
