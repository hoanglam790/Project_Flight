using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocs.Migrations
{
    /// <inheritdoc />
    public partial class Update_FlightDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Documents",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Documents");
        }
    }
}
