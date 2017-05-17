using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Speech.Migrations
{
    public partial class ClientFirstLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientFirst",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientLast",
                table: "Profiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientFirst",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ClientLast",
                table: "Profiles");
        }
    }
}
