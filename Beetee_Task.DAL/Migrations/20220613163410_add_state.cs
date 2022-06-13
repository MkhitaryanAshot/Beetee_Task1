using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beetee_Task.DAL.Migrations
{
    public partial class add_state : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Employees");
        }
    }
}
