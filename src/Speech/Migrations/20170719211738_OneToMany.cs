using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Speech.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Goals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ProfileId",
                table: "Goals",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Profiles_ProfileId",
                table: "Goals",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Profiles_ProfileId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ProfileId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Goals");
        }
    }
}
