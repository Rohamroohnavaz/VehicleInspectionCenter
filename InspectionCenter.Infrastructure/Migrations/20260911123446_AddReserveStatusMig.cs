using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspectionCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReserveStatusMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReserveStatus",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReserveStatus",
                table: "Appointments");
        }
    }
}
