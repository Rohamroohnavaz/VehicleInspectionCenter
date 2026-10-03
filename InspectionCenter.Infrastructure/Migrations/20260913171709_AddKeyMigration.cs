using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CenterId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CenterId",
                table: "Appointments",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CenterId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Appointments");
        }
    }
}
