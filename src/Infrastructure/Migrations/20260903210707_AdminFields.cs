using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rice_ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RiceItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "RiceItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RiceItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RiceItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RiceItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "RiceItems");
        }
    }
}
