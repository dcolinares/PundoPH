using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PundoPH.Migrations
{
    public partial class AddTokenExpirationDateColumnToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpirationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenExpirationDate",
                table: "Users");
        }
    }
}
